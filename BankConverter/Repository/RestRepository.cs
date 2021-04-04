using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BankConverter.Model;

namespace BankConverter.Repository
{
    public class RestRepository : IRestRepository
    {
        private string _url = @"http://www.cbr.ru/scripts/XML_daily.asp";
       
        public async Task<ValCurs> GetCurs(DateTime? selectedDate)
        {
            ObservableCollection<ValCursValute> valCursValutes = new ObservableCollection<ValCursValute>();
            var url = selectedDate == null ? _url : $"{_url}?date_req={selectedDate.Value}";
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpResponse = (HttpWebResponse) await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream(), encoding: Encoding.GetEncoding(1251)))
            {
                var result = await streamReader.ReadToEndAsync();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ValCurs));
                using (var textStream = new StringReader(result))
                {
                    return (ValCurs)xmlSerializer.Deserialize(textStream);
                }
            }
        }

        public async Task<ValCurs> GetCurs()
        {
            return await GetCurs(null);
        }

    }
}
