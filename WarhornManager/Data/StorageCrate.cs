using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WarhornManager
{
    internal class StorageCrate
    {
        private StorageCrateData data;

        #region "Constructors"
        public StorageCrate()
        {
            this.data = new StorageCrateData()
            {
                State = StorageCrateState.initial,
                LastUpdate = DateTime.Now
            };
        }
        public StorageCrate(string inData)
        {
            this.data = StorageCrateDataFromXmlString(inData);
        }

        private static StorageCrateData StorageCrateDataFromXmlString(string inData)
        {
            //XmlSerializer serializer = new(typeof(StorageCrateData));
            DataContractJsonSerializer serializer = new(typeof(StorageCrateData));
            using MemoryStream stream = new(Convert.FromBase64String(inData));
            //StorageCrateData? tempData = (StorageCrateData?)serializer.Deserialize(stream);
            StorageCrateData? tempData = (StorageCrateData?)serializer.ReadObject(stream);
            stream.Close();
            if (tempData != null)
            {
                return tempData;
            }
            else
            {
                Console.Error.WriteLine("Failed to decode StorageCrateDate from XML base64 encoding");
                return new StorageCrateData();
            }
        }
        #endregion

        #region "Variable Access Methods"

        public string ClientId
        {
            get { return this.data.ClientId; }
            set { this.data.ClientId = value; }
        }
        public string AppToken
        {
            get { return this.data.AppToken; }
            set { this.data.AppToken = value; }
        }
        public string AccessToken
        {
            get { return this.data.AccessToken ?? ""; }
            set { this.data.AccessToken = value; }
        }

        public string? RetrieveContext(string key)
        {
            if (this.data.Context == null) return null;
            if (data.Context.TryGetValue(key, out string? value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        public void SetContext(string key, string value)
        {
            this.data.Context ??= new Dictionary<string, string>();
            this.data.Context[key] = value;
            return;
        }
        #endregion

        #region "Local Storage"
        public async Task<ushort> LoadAsync(Blazored.LocalStorage.ILocalStorageService localStorageService, string localStorageKey)
        {
            try
            {
                string? loadExistingToken = await localStorageService.GetItemAsStringAsync(localStorageKey);
                if (loadExistingToken == null)
                {
                    Console.WriteLine("Attempted to load local StorageCrate: None found");
                    return 2;
                }
                else
                {
                    this.data = StorageCrateDataFromXmlString(loadExistingToken);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error reading StorageCrate from local storage");
                Console.Error?.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }
        public async Task<int> SaveAsync(Blazored.LocalStorage.ILocalStorageService localStorageService, string localStorageKey)
        {
            try
            {
                await localStorageService.SetItemAsStringAsync(localStorageKey, this.EncodedData);
            }
            catch (Exception ex)    
            {
                Console.Error.WriteLine("Error writing StorageCrate to local storage");
                Console.Error?.WriteLine(ex.Message);
                return 1;
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// Data contents as a serialized base64 string.
        /// </summary>
        public string EncodedData
        {
            get
            {
                if (this.data != null)
                {
                    //XmlSerializer serializer = new(typeof(StorageCrateData)); //Errors if StorageCrateData is Private
                    DataContractJsonSerializer serializer = new(typeof(StorageCrateData));
                    using MemoryStream stream = new();
                    //serializer.Serialize(stream, this.data);
                    serializer.WriteObject(stream, this.data);
                    return Convert.ToBase64String(stream.ToArray());
                }
                else
                {
                    return "";
                }
            }
        }

        private enum StorageCrateState : uint
        {
            initial = 0,
            error = 99,
            login = 1,
            ready = 2,
            loading = 3
        }

        #region "Data containing class"
        //Using DataContract and DataContractJsonSerializer over XmlSerializer so this class can remain private
        [DataContract]
        private class StorageCrateData
        {
            [DataMember]
            public StorageCrateState State = StorageCrateState.initial;
            [DataMember]
            public DateTime LastUpdate;
            [DataMember]
            public string ClientId = "";
            [DataMember]
            public string AppToken = "";
            [DataMember]
            [XmlElementAttribute(IsNullable = false)]
            public string? AccessToken;

            [DataMember]
            public Dictionary<string, string>? Context = new();

            [DataMember]
            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.User>? Players;

            [DataMember]
            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.Session>? Sessions;

            [DataMember]
            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.Event>? Events;
        }
        #endregion
    }
}
