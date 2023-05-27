using System;
using System.Net.Http;

namespace RestClientBCF.restclient.constants
{
    public class RestConstants
    {

        public static HttpClient CLIENT = new HttpClient { BaseAddress = new Uri("http://localhost:8080/") };

        public const String BCF = "Burgos C.F.";

        public const String APP_JSON = "application/json";
        public const String MULT_PART_FORM = "multipart/form-data";
        public const String CONTENT_TYPE = "Content-Type";

        public const String PLAYER_LEVEL_OF_DATA = "?level=";
        public const int PLAYER_DATA_SIMPLE = 0;
        public const int PLAYER_DATA_SIMPLE_WITH_ID = 1;
        public const int PLAYER_DATA_COMPLETE = 2;

        public const String ALL_PARAM_TRUE = "?all=true";


        public const int PLFM_DATA_PLAYERS_WITHOUT_RESULT = 0;
        public const int PLFM_DATA_PLAYERS_WITH_RESULT_DATA_TABLE = 1;
        public const int PLFM_ALL_DATA = 2;
        public const String FT_DAY_TYPE_OF_DATA_PARAM = "?typeOfData=";

        public const string LOGS_SUPPORT_MSG_PARAM = "?clientErrorMessage=";

        public const char ERROR_REST_DELIMITER = '?';

    }
}
