using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;

namespace Knowit.EpiserverFramework.EpiCore.Features.SelectionFactories
{
    /// <summary>
    /// Selection factory for setting image slide interval
    /// </summary>
    public class SlideIntervalSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "5 sekunder", Value = "5000" },
                new SelectItem() { Text = "10 sekunder", Value = "10000" },
                new SelectItem() { Text = "15 sekunder", Value = "15000" },
                new SelectItem() { Text = "20 sekunder", Value = "20000" },
                new SelectItem() { Text = "25 sekunder", Value = "25000" },
                new SelectItem() { Text = "30 sekunder", Value = "30000" }
            };
        }
    }
}
