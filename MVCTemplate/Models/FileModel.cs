﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLAExemptionTool.Models
{

    public class FileModel
    {
        [Required(ErrorMessage = "Please select file.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.elsx)$", ErrorMessage = "Only Image files allowed.")]
        public HttpPostedFileBase PostedFile { get; set; }
    }

}