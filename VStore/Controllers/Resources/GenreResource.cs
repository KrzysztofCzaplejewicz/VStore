using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VStore.Controllers.Resources
{
    public class GenreResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<VideoResource> Videos { get; set; }

        public GenreResource()
        {
            Videos = new Collection<VideoResource>();
        }

    }
}