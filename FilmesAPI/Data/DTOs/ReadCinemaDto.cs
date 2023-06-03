﻿using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
     
        public string Name { get; set; }

        public ReadAddressDto Address { get; set; }
    }
}