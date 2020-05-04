﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCMS.Helpers
{
    public class Enums
    {
        public enum OrderCartStatusTypes
        {
            ACTIVE = 0,
            ABANDON = 1,
            EXPIRED = 2,
            COMPLETED = 3,
            PAYMENT_FAILED = 4
        }
        public enum EntityTypes
        {
            QuestionCard=0,
            ExamCard=1,
            TopicCard=2,
            Bundle=3
        }

        public enum ExamTypes
        {
            YKS = 0,
            TYT = 1,
            AYT = 2,
            LGS = 3,
            KPSS = 4,
            AÖÖ = 5,
            AÖL = 6,
            MAÖL = 7,
            AÖİHL = 8
        }
        public enum ProductSpecValueTypes
        {
            Number=0,
            Text=1,
            Decimal=2,
            SelectList=3,
            Datetime=4,
            Multiselect=5,
            Boolean=6

        }
        public enum MenuLocations
        {
            Header=0,
            LeftAside=1,
            RightAside=2
        }
        


    }
}
