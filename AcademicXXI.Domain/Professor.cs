﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Domain
{
    public class Professor : BaseDomain
    {
        public String FullName { get; set; }
        public String DocumentID { get; set; }

        //One Professor has many RecordDetails
        public virtual List<RecordDetails> RecordDetails { get; set; }
    }
}