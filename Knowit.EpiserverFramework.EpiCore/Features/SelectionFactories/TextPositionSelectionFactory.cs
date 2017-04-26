using System.Collections.Generic;
using System.Linq;
using EPiServer.Shell.ObjectEditing;

namespace Knowit.EpiserverFramework.EpiCore.Features.SelectionFactories
{
    /// <summary>
    /// Text position selection factory
    /// </summary>
    public class TextPositionSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var selectItems = new List<ISelectItem>();

            var positions = new[]
            {
                    new { Text = "Nedre högra", Value = "bottomright" },
                    new { Text = "Centrerad", Value = "center" }
                }.ToList();

            positions.ForEach(p => selectItems.Add(new SelectItem() { Text = p.Text, Value = p.Value }));

            return selectItems;
        }
    }
}
