﻿namespace VStore.Controllers.Resources
{
    public class VideoResource
    {
        public int Id { get; set; }
        public KeyValuePair Genre { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}