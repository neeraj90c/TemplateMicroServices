﻿namespace EventDetail.DTO
{
    public class EventDetailResponseDTO
    {
        public int EDetailId { get; set; }
        public int EventId { get; set; }
        public int ItemId { get; set; }
        public int IsActive {  get; set; }
        public int IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

    }
    public class EventDetailList
    {
        public IEnumerable<EventDetailResponseDTO> Items { get; set; }
    }
}
