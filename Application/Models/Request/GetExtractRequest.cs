﻿using System.ComponentModel.DataAnnotations;

namespace Application.Models.Request
{
  public class GetExtractRequest
  {
    [Required(ErrorMessage = "Você deve informar o id conta")]
    public string AccountId { get; set; }    
    [Required(ErrorMessage = "Você deve informar o dia mês ano da seguinte forma com apenas números => ddmmaaaa")]
    public string DiaMesAno {get;set;}
  }
}
