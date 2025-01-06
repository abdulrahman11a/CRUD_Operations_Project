﻿namespace DAL.Entities.CoomonModel
{
    public class ModelBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
