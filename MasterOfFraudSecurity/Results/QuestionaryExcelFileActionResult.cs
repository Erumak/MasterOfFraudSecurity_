using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MasterOfFraudSecurity.Entities;
using OfficeOpenXml;

namespace MasterOfFraudSecurity.Results
{
    public class QuestionaryExcelFileActionResult: IHttpActionResult
    {
        private readonly Questionary[] _data;
        private readonly string _filename;

        public QuestionaryExcelFileActionResult(Questionary[] data, string fileName)
        {
            _data = data;
            _filename = fileName;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");
                worksheet.Cells["A1"].LoadFromCollection(_data, true);

                const string dateFormat = "dd/mm/yyyy";
                worksheet.Cells[1, 2, _data.Length + 1, 2].Style.Numberformat.Format = dateFormat;
                worksheet.Cells[1, 6, _data.Length + 1, 6].Style.Numberformat.Format = dateFormat;
                worksheet.Cells.AutoFitColumns();
                package.SaveAs(stream);
            }
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {Content = new ByteArrayContent(stream.GetBuffer())};

            responseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = _filename
            };
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            return Task.FromResult(responseMessage);
        }
    }
}