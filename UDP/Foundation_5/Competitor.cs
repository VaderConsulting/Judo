using Newtonsoft.Json;

using System.Collections.Generic;

namespace Foundation
{
    public class Competitor
    {
        #region Constants

        #endregion

        #region Delegates

        #endregion

        #region Events

        #endregion

        #region Enums

        #endregion

        #region DLL Imports

        #endregion

        #region Fields

        #endregion

        #region Properties

        [JsonProperty("id_person")]
        public string IdPerson
        {
            get; set;
        }
        [JsonProperty("family_name")]
        public string FamilyName
        {
            get; set;
        }
        [JsonProperty("given_name")]
        public string GivenName
        {
            get; set;
        }
        [JsonProperty("country")]
        public string Country
        {
            get; set;
        }
        [JsonProperty("country_short")]
        public string CountryShort
        {
            get; set;
        }
        [JsonProperty("version")]
        public string Version
        {
            get; set;
        }
        [JsonProperty("pic_folder")]
        public string PicFolder
        {
            get; set;
        }
        [JsonProperty("pic_name")]
        public string PicName
        {
            get; set;
        }
        [JsonProperty("place")]
        public string Place
        {
            get; set;
        }
        [JsonProperty("id_weight")]
        public string IdWeight
        {
            get; set;
        }
        [JsonProperty("points")]
        public string Points
        {
            get; set;
        }
        [JsonProperty("id_country")]
        public string IdCountry
        {
            get; set;
        }
        [JsonProperty("weight_name")]
        public string WeightName
        {
            get; set;
        }
        [JsonProperty("gender")]
        public string Gender
        {
            get; set;
        }
        [JsonProperty("all_points")]
        public Dictionary<string, string> AllPoints
        {
            get; set;
        }
        [JsonProperty("place_prev")]
        public string PlacePrev
        {
            get; set;
        }
        [JsonProperty("ppic")]
        public string Ppic
        {
            get; set;
        }
        [JsonProperty("all_points_comp")]
        public List<object> AllPointsComp
        {
            get; set;
        }
        [JsonProperty("all_ogq_points_comp")]
        public List<object> AllOgqPointsComp
        {
            get; set;
        }

        #endregion

        #region Constructors and Destructor

        #endregion

        #region Event Handlers

        #endregion

        #region Private Methods

        #endregion

        #region Public Methods

        public static string FromClass<T>(T data, bool isEmptyToNull = false, JsonSerializerSettings jsonSettings = null)
        {
            string response = string.Empty;

            if (!EqualityComparer<T>.Default.Equals(data, default(T)))
            {
                response = JsonConvert.SerializeObject(data, jsonSettings);
            }

            return isEmptyToNull ? (response == "{}" ? "null" : response) : response;
        }

        public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
        {
            var response = default(T);

            if (!string.IsNullOrEmpty(data))
            {
                response = jsonSettings == null ? JsonConvert.DeserializeObject<T>(data) : JsonConvert.DeserializeObject<T>(data, jsonSettings);
            }

            return response;
        }

        #endregion

        #region Classes

        // By my own convention all classes should be in their own file, however sometimes it makes sense to include a class within the same file as it's parent Namespace

        #endregion
    }
}
