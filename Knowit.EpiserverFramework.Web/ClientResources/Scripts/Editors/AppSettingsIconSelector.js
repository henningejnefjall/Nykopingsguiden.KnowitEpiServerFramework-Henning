define([
// Dojo
    "dojo/_base/declare",
    "dojo/_base/array",

    "dojox/html/entities",
// EPi
    "epi-cms/contentediting/editors/SelectionEditor",

],
function (
// Dojo
    declare,
    array,
    entities,

// EPi
    SelectionEditor

) {
    return declare("knowit/editors/AppSettingsIconSelector", [SelectionEditor], {
        // EPi is removing html so we override this function
        _setSelectionsAttr: function (newSelections) {
            this.set("options", array.map(newSelections, function (item) {
                return {
                    label: item.text,
                    value: item.value,
                    selected: (item.value === this.value) || (!item.value && !this.value)
                };
            }, this));
        },
    });
});