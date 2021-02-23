using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace quotes.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly ILogger<QuotesController> _logger;

        public QuotesController(ILogger<QuotesController> logger)
        {
            _logger = logger;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            Quote thisQuote = new Quote();
            using (var connection = new SqlConnection("Server=tcp:quotesdb.database.windows.net,1433;Initial Catalog=quotesdatabase;Persist Security Info=False;User ID=donschenck;Password=reallylongpassword99!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                var command = new SqlCommand("SELECT id, author, quotetext FROM Quotes WHERE Id=" + id.ToString(), connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        thisQuote.Id = Convert.ToInt32(reader[0]);
                        thisQuote.Author = reader[1].ToString();
                        thisQuote.QuoteText = reader[2].ToString();
                    }
                }
            }
            return thisQuote;
        }
        
        [HttpGet]
        public List<Quote> Get()
        {
            List<Quote> q = new List<Quote>();
            using (var connection = new SqlConnection("Server=tcp:quotesdb.database.windows.net,1433;Initial Catalog=quotesdatabase;Persist Security Info=False;User ID=donschenck;Password=reallylongpassword99!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                var command = new SqlCommand("SELECT id, author, quotetext FROM Quotes ORDER BY Id", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Quote thisQuote = new Quote();
                        thisQuote.Id = Convert.ToInt32(reader[0]);
                        thisQuote.Author = reader[1].ToString();
                        thisQuote.QuoteText = reader[2].ToString();
                        q.Add(thisQuote);
                    }
                }
            }
            return q;
        }
    }
}
