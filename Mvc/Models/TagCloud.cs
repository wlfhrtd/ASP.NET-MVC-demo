using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Mvc.Models
{
    public class TagCloud
    {
        public int MaxSize { get; set; }

        public int MinSize { get; set; }

        public string BaseLinkClassName { get; set; }

        public string ContainerClassName { get; set; }

        private int minRank;

        private int maxRank;

        private List<TagCloudItem> items { get; set; }

        public ReadOnlyCollection<TagCloudItem> Items
        {
            get => items != null ? new ReadOnlyCollection<TagCloudItem>(items) : null;
        }


        public TagCloud()
        {
            MaxSize = 10;
            MinSize = 1;
            maxRank = 1;
            minRank = 1;
            BaseLinkClassName = "linkLevel-";
            ContainerClassName = "tagcloud";
            items = new();
        }


        public void AddItem(TagCloudItem item)
        {
            items.Add(item);
            minRank = items.Min(x => x.Weight);
            maxRank = items.Max(x => x.Weight);
        }

        public string GetLinkItemClassName(TagCloudItem item)
        {
            if (maxRank == MaxSize && minRank == MinSize)
            {
                return string.Concat(BaseLinkClassName, item.Weight);
            }

            int normalizedRank = 1 + (item.Weight - minRank) * (MaxSize - 1) / (maxRank - minRank);
            return string.Concat(BaseLinkClassName, normalizedRank);
        }
    }
}
