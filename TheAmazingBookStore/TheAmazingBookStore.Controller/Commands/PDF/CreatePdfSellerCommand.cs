using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Commands.FindCommand;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.PDF
{
    public class CreatePdfSellerCommand : ICommand, IPdfReporter
    {
        private readonly IBookStoreContext context;
        public CreatePdfSellerCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

        }
        public string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            var findSeller = new FindSellerCommand(this.context);

            Seller seller = this.context.Sellers.Find(id);

            string result = (findSeller.Execute(new List<string> { $"{id}" }));
            FileStream fs = new FileStream($"{seller.FirstName} {seller.LastName}.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph(result));
            doc.Close();

            return $"The PDF document for {seller.FirstName} {seller.LastName} is ready.";
        }
    }
}
