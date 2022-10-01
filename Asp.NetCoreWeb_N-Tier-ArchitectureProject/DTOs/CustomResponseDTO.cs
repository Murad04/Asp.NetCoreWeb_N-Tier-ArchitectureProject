﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T? Data { get; set; } 

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String>? Errors { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode, T data)
        {
            return new CustomResponseDTO<T> { Data = data, StatusCode = statusCode, Errors = null };
        }

        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = null };
        }

        public static CustomResponseDTO<T> Fail(List<string> errors, int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDTO<T> Fail(string errors, int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
