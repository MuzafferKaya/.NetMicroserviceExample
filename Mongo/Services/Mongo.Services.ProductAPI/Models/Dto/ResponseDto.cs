﻿namespace Mongo.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Results { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
