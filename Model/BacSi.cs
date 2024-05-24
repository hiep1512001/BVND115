using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVND115.Model
{
    public class BacSi
    {
        [JsonProperty ("MaBS")]
        public string MaBS {  get; set; }
        [JsonProperty("TenBS")]
        public string TenBS { get; set; }
        [JsonProperty("GioiTinh")]
        public string GioiTinh { get; set; }
        [JsonProperty("ChuyenKhoa")]
        public string ChuyenKhoa {  get; set; }
        [JsonProperty("LichKham")]
        public string LichKham {  get; set; }
        [JsonProperty("GiaKham")]
        public string GiaKham { get; set; }
    }
}
