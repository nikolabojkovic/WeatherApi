
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.Domain;

namespace WeatherApi.CustomServices {
    public class WeatherService : IWeatherService {
        
        private readonly IRouter _router;
        public string Units { get; set; } = "metric";

        public WeatherService(IRouter router) {
            _router = router;
        }

        public async Task<Forecast> ForcastByNameOfThe(string city) {

            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?q={city}&units={Units}");
          /* 
            var apiWeatherDataString = @"
                {
                    ""cod"": ""200"",
                    ""message"": 0.0056,
                    ""cnt"": 40,
                    ""list"": [
                        {
                            ""dt"": 1557586800,
                            ""main"": {
                                ""temp"": 22.76,
                                ""temp_min"": 22.53,
                                ""temp_max"": 22.76,
                                ""pressure"": 1012.99,
                                ""sea_level"": 1012.99,
                                ""grnd_level"": 999.78,
                                ""humidity"": 44,
                                ""temp_kf"": 0.23
                            },
                            ""weather"": [
                                {
                                    ""id"": 802,
                                    ""main"": ""Clouds"",
                                    ""description"": ""scattered clouds"",
                                    ""icon"": ""03d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 34
                            },
                            ""wind"": {
                                ""speed"": 2.4,
                                ""deg"": 122.995
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-11 15:00:00""
                        },
                        {
                            ""dt"": 1557597600,
                            ""main"": {
                                ""temp"": 17.15,
                                ""temp_min"": 16.98,
                                ""temp_max"": 17.15,
                                ""pressure"": 1012.83,
                                ""sea_level"": 1012.83,
                                ""grnd_level"": 999.46,
                                ""humidity"": 58,
                                ""temp_kf"": 0.17
                            },
                            ""weather"": [
                                {
                                    ""id"": 802,
                                    ""main"": ""Clouds"",
                                    ""description"": ""scattered clouds"",
                                    ""icon"": ""03n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 39
                            },
                            ""wind"": {
                                ""speed"": 2.99,
                                ""deg"": 102.314
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-11 18:00:00""
                        },
                        {
                            ""dt"": 1557608400,
                            ""main"": {
                                ""temp"": 15.39,
                                ""temp_min"": 15.28,
                                ""temp_max"": 15.39,
                                ""pressure"": 1013.93,
                                ""sea_level"": 1013.93,
                                ""grnd_level"": 1000.43,
                                ""humidity"": 69,
                                ""temp_kf"": 0.12
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 93
                            },
                            ""wind"": {
                                ""speed"": 3.81,
                                ""deg"": 115.08
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-11 21:00:00""
                        },
                        {
                            ""dt"": 1557619200,
                            ""main"": {
                                ""temp"": 14.14,
                                ""temp_min"": 14.08,
                                ""temp_max"": 14.14,
                                ""pressure"": 1013.95,
                                ""sea_level"": 1013.95,
                                ""grnd_level"": 1000.11,
                                ""humidity"": 68,
                                ""temp_kf"": 0.06
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 96
                            },
                            ""wind"": {
                                ""speed"": 2.82,
                                ""deg"": 113.362
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-12 00:00:00""
                        },
                        {
                            ""dt"": 1557630000,
                            ""main"": {
                                ""temp"": 12.14,
                                ""temp_min"": 12.14,
                                ""temp_max"": 12.14,
                                ""pressure"": 1013.71,
                                ""sea_level"": 1013.71,
                                ""grnd_level"": 999.84,
                                ""humidity"": 77,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 87
                            },
                            ""wind"": {
                                ""speed"": 1.66,
                                ""deg"": 120.816
                            },
                            ""rain"": {
                                ""3h"": 0.125
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-12 03:00:00""
                        },
                        {
                            ""dt"": 1557640800,
                            ""main"": {
                                ""temp"": 15.29,
                                ""temp_min"": 15.29,
                                ""temp_max"": 15.29,
                                ""pressure"": 1014.06,
                                ""sea_level"": 1014.06,
                                ""grnd_level"": 1000.26,
                                ""humidity"": 72,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 94
                            },
                            ""wind"": {
                                ""speed"": 1.64,
                                ""deg"": 154.156
                            },
                            ""rain"": {
                                ""3h"": 0.063
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-12 06:00:00""
                        },
                        {
                            ""dt"": 1557651600,
                            ""main"": {
                                ""temp"": 20.35,
                                ""temp_min"": 20.35,
                                ""temp_max"": 20.35,
                                ""pressure"": 1014.03,
                                ""sea_level"": 1014.03,
                                ""grnd_level"": 1000.49,
                                ""humidity"": 55,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 97
                            },
                            ""wind"": {
                                ""speed"": 3.18,
                                ""deg"": 129.558
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-12 09:00:00""
                        },
                        {
                            ""dt"": 1557662400,
                            ""main"": {
                                ""temp"": 23.31,
                                ""temp_min"": 23.31,
                                ""temp_max"": 23.31,
                                ""pressure"": 1013.24,
                                ""sea_level"": 1013.24,
                                ""grnd_level"": 999.76,
                                ""humidity"": 46,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 95
                            },
                            ""wind"": {
                                ""speed"": 5.44,
                                ""deg"": 126.488
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-12 12:00:00""
                        },
                        {
                            ""dt"": 1557673200,
                            ""main"": {
                                ""temp"": 22.9,
                                ""temp_min"": 22.9,
                                ""temp_max"": 22.9,
                                ""pressure"": 1012.14,
                                ""sea_level"": 1012.14,
                                ""grnd_level"": 998.34,
                                ""humidity"": 55,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 6.06,
                                ""deg"": 112.5
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-12 15:00:00""
                        },
                        {
                            ""dt"": 1557684000,
                            ""main"": {
                                ""temp"": 17.99,
                                ""temp_min"": 17.99,
                                ""temp_max"": 17.99,
                                ""pressure"": 1012.72,
                                ""sea_level"": 1012.72,
                                ""grnd_level"": 999.11,
                                ""humidity"": 74,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 5.07,
                                ""deg"": 99.771
                            },
                            ""rain"": {
                                ""3h"": 2.188
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-12 18:00:00""
                        },
                        {
                            ""dt"": 1557694800,
                            ""main"": {
                                ""temp"": 16.38,
                                ""temp_min"": 16.38,
                                ""temp_max"": 16.38,
                                ""pressure"": 1013.59,
                                ""sea_level"": 1013.59,
                                ""grnd_level"": 1000.3,
                                ""humidity"": 76,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 4.61,
                                ""deg"": 107.585
                            },
                            ""rain"": {
                                ""3h"": 0.438
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-12 21:00:00""
                        },
                        {
                            ""dt"": 1557705600,
                            ""main"": {
                                ""temp"": 15.23,
                                ""temp_min"": 15.23,
                                ""temp_max"": 15.23,
                                ""pressure"": 1013.63,
                                ""sea_level"": 1013.63,
                                ""grnd_level"": 1000.3,
                                ""humidity"": 87,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 5.2,
                                ""deg"": 83.068
                            },
                            ""rain"": {
                                ""3h"": 1.874
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-13 00:00:00""
                        },
                        {
                            ""dt"": 1557716400,
                            ""main"": {
                                ""temp"": 14.49,
                                ""temp_min"": 14.49,
                                ""temp_max"": 14.49,
                                ""pressure"": 1013.68,
                                ""sea_level"": 1013.68,
                                ""grnd_level"": 1000.47,
                                ""humidity"": 92,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 5.42,
                                ""deg"": 69.966
                            },
                            ""rain"": {
                                ""3h"": 6.312
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-13 03:00:00""
                        },
                        {
                            ""dt"": 1557727200,
                            ""main"": {
                                ""temp"": 15.06,
                                ""temp_min"": 15.06,
                                ""temp_max"": 15.06,
                                ""pressure"": 1014.48,
                                ""sea_level"": 1014.48,
                                ""grnd_level"": 1001.11,
                                ""humidity"": 87,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 5.64,
                                ""deg"": 65.535
                            },
                            ""rain"": {
                                ""3h"": 2.063
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-13 06:00:00""
                        },
                        {
                            ""dt"": 1557738000,
                            ""main"": {
                                ""temp"": 16.35,
                                ""temp_min"": 16.35,
                                ""temp_max"": 16.35,
                                ""pressure"": 1015.69,
                                ""sea_level"": 1015.69,
                                ""grnd_level"": 1001.83,
                                ""humidity"": 82,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 6.13,
                                ""deg"": 87.651
                            },
                            ""rain"": {
                                ""3h"": 0.812
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-13 09:00:00""
                        },
                        {
                            ""dt"": 1557748800,
                            ""main"": {
                                ""temp"": 18.76,
                                ""temp_min"": 18.76,
                                ""temp_max"": 18.76,
                                ""pressure"": 1014.87,
                                ""sea_level"": 1014.87,
                                ""grnd_level"": 1000.61,
                                ""humidity"": 71,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 4.8,
                                ""deg"": 87.707
                            },
                            ""rain"": {
                                ""3h"": 3.188
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-13 12:00:00""
                        },
                        {
                            ""dt"": 1557759600,
                            ""main"": {
                                ""temp"": 17.15,
                                ""temp_min"": 17.15,
                                ""temp_max"": 17.15,
                                ""pressure"": 1013.7,
                                ""sea_level"": 1013.7,
                                ""grnd_level"": 999.45,
                                ""humidity"": 79,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 1.65,
                                ""deg"": 212.354
                            },
                            ""rain"": {
                                ""3h"": 5.125
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-13 15:00:00""
                        },
                        {
                            ""dt"": 1557770400,
                            ""main"": {
                                ""temp"": 8.05,
                                ""temp_min"": 8.05,
                                ""temp_max"": 8.05,
                                ""pressure"": 1014.4,
                                ""sea_level"": 1014.4,
                                ""grnd_level"": 1001.3,
                                ""humidity"": 93,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 8.32,
                                ""deg"": 253.225
                            },
                            ""rain"": {
                                ""3h"": 5.937
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-13 18:00:00""
                        },
                        {
                            ""dt"": 1557781200,
                            ""main"": {
                                ""temp"": 7.05,
                                ""temp_min"": 7.05,
                                ""temp_max"": 7.05,
                                ""pressure"": 1015.07,
                                ""sea_level"": 1015.07,
                                ""grnd_level"": 1000.76,
                                ""humidity"": 93,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 7.41,
                                ""deg"": 260.165
                            },
                            ""rain"": {
                                ""3h"": 3.5
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-13 21:00:00""
                        },
                        {
                            ""dt"": 1557792000,
                            ""main"": {
                                ""temp"": 7.5,
                                ""temp_min"": 7.5,
                                ""temp_max"": 7.5,
                                ""pressure"": 1015.03,
                                ""sea_level"": 1015.03,
                                ""grnd_level"": 1000.14,
                                ""humidity"": 94,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 502,
                                    ""main"": ""Rain"",
                                    ""description"": ""heavy intensity rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 7.18,
                                ""deg"": 247.39
                            },
                            ""rain"": {
                                ""3h"": 13.5
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-14 00:00:00""
                        },
                        {
                            ""dt"": 1557802800,
                            ""main"": {
                                ""temp"": 7.93,
                                ""temp_min"": 7.93,
                                ""temp_max"": 7.93,
                                ""pressure"": 1015.31,
                                ""sea_level"": 1015.31,
                                ""grnd_level"": 1000.78,
                                ""humidity"": 93,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 97
                            },
                            ""wind"": {
                                ""speed"": 5.85,
                                ""deg"": 234.245
                            },
                            ""rain"": {
                                ""3h"": 0.188
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-14 03:00:00""
                        },
                        {
                            ""dt"": 1557813600,
                            ""main"": {
                                ""temp"": 7.82,
                                ""temp_min"": 7.82,
                                ""temp_max"": 7.82,
                                ""pressure"": 1016.63,
                                ""sea_level"": 1016.63,
                                ""grnd_level"": 1002.91,
                                ""humidity"": 92,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 97
                            },
                            ""wind"": {
                                ""speed"": 3.8,
                                ""deg"": 250.099
                            },
                            ""rain"": {
                                ""3h"": 0.124
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-14 06:00:00""
                        },
                        {
                            ""dt"": 1557824400,
                            ""main"": {
                                ""temp"": 12.33,
                                ""temp_min"": 12.33,
                                ""temp_max"": 12.33,
                                ""pressure"": 1017.22,
                                ""sea_level"": 1017.22,
                                ""grnd_level"": 1003.35,
                                ""humidity"": 76,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 803,
                                    ""main"": ""Clouds"",
                                    ""description"": ""broken clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 68
                            },
                            ""wind"": {
                                ""speed"": 2.77,
                                ""deg"": 261.32
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-14 09:00:00""
                        },
                        {
                            ""dt"": 1557835200,
                            ""main"": {
                                ""temp"": 13.34,
                                ""temp_min"": 13.34,
                                ""temp_max"": 13.34,
                                ""pressure"": 1016.61,
                                ""sea_level"": 1016.61,
                                ""grnd_level"": 1003.15,
                                ""humidity"": 75,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 803,
                                    ""main"": ""Clouds"",
                                    ""description"": ""broken clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 83
                            },
                            ""wind"": {
                                ""speed"": 2,
                                ""deg"": 327.632
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-14 12:00:00""
                        },
                        {
                            ""dt"": 1557846000,
                            ""main"": {
                                ""temp"": 13.06,
                                ""temp_min"": 13.06,
                                ""temp_max"": 13.06,
                                ""pressure"": 1015.83,
                                ""sea_level"": 1015.83,
                                ""grnd_level"": 1002.12,
                                ""humidity"": 84,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 95
                            },
                            ""wind"": {
                                ""speed"": 2.4,
                                ""deg"": 287.929
                            },
                            ""rain"": {
                                ""3h"": 0.5
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-14 15:00:00""
                        },
                        {
                            ""dt"": 1557856800,
                            ""main"": {
                                ""temp"": 12.35,
                                ""temp_min"": 12.35,
                                ""temp_max"": 12.35,
                                ""pressure"": 1015.41,
                                ""sea_level"": 1015.41,
                                ""grnd_level"": 1000.9,
                                ""humidity"": 92,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 97
                            },
                            ""wind"": {
                                ""speed"": 4.25,
                                ""deg"": 329.159
                            },
                            ""rain"": {
                                ""3h"": 2.25
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-14 18:00:00""
                        },
                        {
                            ""dt"": 1557867600,
                            ""main"": {
                                ""temp"": 11.77,
                                ""temp_min"": 11.77,
                                ""temp_max"": 11.77,
                                ""pressure"": 1015.54,
                                ""sea_level"": 1015.54,
                                ""grnd_level"": 1001.79,
                                ""humidity"": 97,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 2.73,
                                ""deg"": 240.562
                            },
                            ""rain"": {
                                ""3h"": 9.062
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-14 21:00:00""
                        },
                        {
                            ""dt"": 1557878400,
                            ""main"": {
                                ""temp"": 11.05,
                                ""temp_min"": 11.05,
                                ""temp_max"": 11.05,
                                ""pressure"": 1014.99,
                                ""sea_level"": 1014.99,
                                ""grnd_level"": 1000.26,
                                ""humidity"": 97,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 3.22,
                                ""deg"": 267.9
                            },
                            ""rain"": {
                                ""3h"": 2.813
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-15 00:00:00""
                        },
                        {
                            ""dt"": 1557889200,
                            ""main"": {
                                ""temp"": 9.06,
                                ""temp_min"": 9.06,
                                ""temp_max"": 9.06,
                                ""pressure"": 1014.28,
                                ""sea_level"": 1014.28,
                                ""grnd_level"": 999.95,
                                ""humidity"": 96,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 93
                            },
                            ""wind"": {
                                ""speed"": 4.22,
                                ""deg"": 242.274
                            },
                            ""rain"": {
                                ""3h"": 0.25
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-15 03:00:00""
                        },
                        {
                            ""dt"": 1557900000,
                            ""main"": {
                                ""temp"": 10.25,
                                ""temp_min"": 10.25,
                                ""temp_max"": 10.25,
                                ""pressure"": 1014.05,
                                ""sea_level"": 1014.05,
                                ""grnd_level"": 1000.49,
                                ""humidity"": 90,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 90
                            },
                            ""wind"": {
                                ""speed"": 2.87,
                                ""deg"": 249.442
                            },
                            ""rain"": {},
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-15 06:00:00""
                        },
                        {
                            ""dt"": 1557910800,
                            ""main"": {
                                ""temp"": 13.95,
                                ""temp_min"": 13.95,
                                ""temp_max"": 13.95,
                                ""pressure"": 1013.77,
                                ""sea_level"": 1013.77,
                                ""grnd_level"": 1000.38,
                                ""humidity"": 79,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 804,
                                    ""main"": ""Clouds"",
                                    ""description"": ""overcast clouds"",
                                    ""icon"": ""04d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 1.24,
                                ""deg"": 244.18
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-15 09:00:00""
                        },
                        {
                            ""dt"": 1557921600,
                            ""main"": {
                                ""temp"": 13.63,
                                ""temp_min"": 13.63,
                                ""temp_max"": 13.63,
                                ""pressure"": 1012.34,
                                ""sea_level"": 1012.34,
                                ""grnd_level"": 998.98,
                                ""humidity"": 87,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 1.54,
                                ""deg"": 311.038
                            },
                            ""rain"": {
                                ""3h"": 2.188
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-15 12:00:00""
                        },
                        {
                            ""dt"": 1557932400,
                            ""main"": {
                                ""temp"": 15.79,
                                ""temp_min"": 15.79,
                                ""temp_max"": 15.79,
                                ""pressure"": 1011.3,
                                ""sea_level"": 1011.3,
                                ""grnd_level"": 997.74,
                                ""humidity"": 80,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 89
                            },
                            ""wind"": {
                                ""speed"": 1.74,
                                ""deg"": 316.682
                            },
                            ""rain"": {
                                ""3h"": 0.25
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-15 15:00:00""
                        },
                        {
                            ""dt"": 1557943200,
                            ""main"": {
                                ""temp"": 13.95,
                                ""temp_min"": 13.95,
                                ""temp_max"": 13.95,
                                ""pressure"": 1010.55,
                                ""sea_level"": 1010.55,
                                ""grnd_level"": 996.81,
                                ""humidity"": 91,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 84
                            },
                            ""wind"": {
                                ""speed"": 3.25,
                                ""deg"": 311.742
                            },
                            ""rain"": {
                                ""3h"": 2
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-15 18:00:00""
                        },
                        {
                            ""dt"": 1557954000,
                            ""main"": {
                                ""temp"": 13.45,
                                ""temp_min"": 13.45,
                                ""temp_max"": 13.45,
                                ""pressure"": 1009.41,
                                ""sea_level"": 1009.41,
                                ""grnd_level"": 995.68,
                                ""humidity"": 95,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 4.35,
                                ""deg"": 346.015
                            },
                            ""rain"": {
                                ""3h"": 6.812
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-15 21:00:00""
                        },
                        {
                            ""dt"": 1557964800,
                            ""main"": {
                                ""temp"": 12.85,
                                ""temp_min"": 12.85,
                                ""temp_max"": 12.85,
                                ""pressure"": 1007.34,
                                ""sea_level"": 1007.34,
                                ""grnd_level"": 993.69,
                                ""humidity"": 96,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 502,
                                    ""main"": ""Rain"",
                                    ""description"": ""heavy intensity rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 4.02,
                                ""deg"": 296.922
                            },
                            ""rain"": {
                                ""3h"": 20.563
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-16 00:00:00""
                        },
                        {
                            ""dt"": 1557975600,
                            ""main"": {
                                ""temp"": 12.65,
                                ""temp_min"": 12.65,
                                ""temp_max"": 12.65,
                                ""pressure"": 1006.11,
                                ""sea_level"": 1006.11,
                                ""grnd_level"": 991.48,
                                ""humidity"": 95,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 502,
                                    ""main"": ""Rain"",
                                    ""description"": ""heavy intensity rain"",
                                    ""icon"": ""10n""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 6.49,
                                ""deg"": 295.748
                            },
                            ""rain"": {
                                ""3h"": 15.25
                            },
                            ""sys"": {
                                ""pod"": ""n""
                            },
                            ""dt_txt"": ""2019-05-16 03:00:00""
                        },
                        {
                            ""dt"": 1557986400,
                            ""main"": {
                                ""temp"": 12.55,
                                ""temp_min"": 12.55,
                                ""temp_max"": 12.55,
                                ""pressure"": 1005.63,
                                ""sea_level"": 1005.63,
                                ""grnd_level"": 990.78,
                                ""humidity"": 96,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 501,
                                    ""main"": ""Rain"",
                                    ""description"": ""moderate rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 4.49,
                                ""deg"": 275.837
                            },
                            ""rain"": {
                                ""3h"": 4.625
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-16 06:00:00""
                        },
                        {
                            ""dt"": 1557997200,
                            ""main"": {
                                ""temp"": 11.6,
                                ""temp_min"": 11.6,
                                ""temp_max"": 11.6,
                                ""pressure"": 1005.74,
                                ""sea_level"": 1005.74,
                                ""grnd_level"": 991.55,
                                ""humidity"": 94,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 6.76,
                                ""deg"": 260.729
                            },
                            ""rain"": {
                                ""3h"": 0.625
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-16 09:00:00""
                        },
                        {
                            ""dt"": 1558008000,
                            ""main"": {
                                ""temp"": 10.55,
                                ""temp_min"": 10.55,
                                ""temp_max"": 10.55,
                                ""pressure"": 1005.76,
                                ""sea_level"": 1005.76,
                                ""grnd_level"": 992.73,
                                ""humidity"": 92,
                                ""temp_kf"": 0
                            },
                            ""weather"": [
                                {
                                    ""id"": 500,
                                    ""main"": ""Rain"",
                                    ""description"": ""light rain"",
                                    ""icon"": ""10d""
                                }
                            ],
                            ""clouds"": {
                                ""all"": 100
                            },
                            ""wind"": {
                                ""speed"": 6.14,
                                ""deg"": 251.412
                            },
                            ""rain"": {
                                ""3h"": 0.687
                            },
                            ""sys"": {
                                ""pod"": ""d""
                            },
                            ""dt_txt"": ""2019-05-16 12:00:00""
                        }
                    ],
                    ""city"": {
                        ""id"": 792680,
                        ""name"": ""Belgrade"",
                        ""coord"": {
                            ""lat"": 44.8178,
                            ""lon"": 20.4569
                        },
                        ""country"": ""RS"",
                        ""population"": 1273651
                    }
                }";
                */
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);

            return Forecast.SuppliedFrom(dynamicApiData);
        }

        public async Task<Forecast> ForcastByZip(string code)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"forecast?zip={code}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Forecast.SuppliedFrom(dynamicApiData);
        }

        public async Task<Weather> WeatherByNameOfThe(string city)
        {
            var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?q={city}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);

            return Weather.SuppliedFrom(dynamicApiData);
        }

        public async Task<Weather> WeatherByZipCode(string code)
        {
             var apiWeatherDataString = await _router.SendRequest(HttpMethod.Get, $"weather?zip={code}&units={Units}");
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Weather.SuppliedFrom(dynamicApiData);
        }
    }
}