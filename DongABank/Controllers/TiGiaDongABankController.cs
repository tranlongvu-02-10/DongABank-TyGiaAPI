using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using DongABank.Models;

namespace DongABank.Controllers
{
    public class TiGiaDongABankController : Controller
    {
        public IActionResult Index()
        {
            string siteContent = string.Empty;

            // link JSON của DongA
            string url = "http://www.dongabank.com.vn/exchange/export";

            //dùng HTTPWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //với Đông Á Bank phải thêm 2 dòng lệnh này:
            request.Headers["User-Agent"] = "Mozilla/5.0 ( compatible ) ";
            request.Headers["Accept"] = "*/*";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            //lấy đối tượng Response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //gọi hàm GetResponseStream() để trả về đối tượng Stream
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string data = reader.ReadToEnd();
            //vì dữ liệu bị bao bọc là ngoặc tròn, ta đổi nó thành rỗng để đúng cấu trúc Json
            data = data.Replace(")", "").Replace("(", "");
            //chuyển dữ liệu Json qua C# class:
            TiGiaDongA tigia = (TiGiaDongA)JsonConvert.DeserializeObject(data, typeof(TiGiaDongA));
            //trả về cho View là 1 danh sách các Item (các dòng Tỉ Giá)
            return View(tigia.items);
        }
    }
}