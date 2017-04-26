#Custom block handling

##Custom css class on prerednderd encapsuling div

```
@Html.PropertyFor(x => x.CurrentPage.CarouselBlockArea, new {ItemCssClass = "customCssClass"})
```

##Remove container div
```
@Html.PropertyFor(x => x.CurrentPage.InspirationContent, new { RenderContainer = false, RenderBlockContainer = false })
```