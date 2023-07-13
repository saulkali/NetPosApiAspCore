using Microsoft.EntityFrameworkCore.Metadata;

namespace PyPosApi.common.entities
{
    public class ResponseEntity
    {
        public string Message { get; set; }
        public string Data { get; set; }
        public int Status { get; set; }

    }
}
