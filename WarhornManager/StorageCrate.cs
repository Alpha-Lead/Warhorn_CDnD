using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            XmlSerializer serializer = new(typeof(StorageCrateData));
            using MemoryStream stream = new(Convert.FromBase64String(inData));
            StorageCrateData? tempData = (StorageCrateData?)serializer.Deserialize(stream);
            if (tempData != null)
            {
                this.data = tempData;
            }
            else
            {
                Console.Error.WriteLine("Failed to decode StorageCrateDate from XML base64 encoding");
                this.data = new StorageCrateData();
            }
            stream.Close();
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
                    XmlSerializer serializer = new(typeof(StorageCrateData));
                    using MemoryStream stream = new();
                    serializer.Serialize(stream, this.data);
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
        private class StorageCrateData
        {
            public StorageCrateState State = StorageCrateState.initial;
            public DateTime LastUpdate;
            public string ClientId = "";
            public string AppToken = "";
            [XmlElementAttribute(IsNullable = false)]
            public string? AccessToken;

            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.User>? Players;

            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.Session>? Sessions;

            [XmlElementAttribute(IsNullable = false)]
            public List<Warhorn.API.Types.Event>? Events;
        }
        #endregion
    }
}
