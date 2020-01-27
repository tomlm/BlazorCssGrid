# Blazor CSS Grid layout library
This blazor component makes it super easy to create application layouts for WebApps that look exactly how you want them to.

## Built 100% using CSS 
This library is used to build CSS fragments for BlazorStyled library.

It's usage is inspired by the kind of layouts you can achieve using XAML Grid Controls, and if you are familiar with
laying out an application's controls using grid semantics this will be very familiar to you.

# Install
Add package references

```dotnet add BlazorStyled```

```dotnet add BlazorCssGrid```

Make sure to add the BlazorStyled configuration changess.

# Usage
There are 2 controls which are used inside a StyledElement
* **GridContainer** -  Define the shapes of Rows and Columns
* **GridItem** - Wrapper around any component which defines where the component should be rendered.

## GridContainer
The grid container defines the rows and columns for the grid.

| Property | Description | Example|
|----|----|---|
| **Columns** | defines the number and width of columns, | auto 1fr auto |
| **Rows** | defines the number and height of rows | auto 1fr auto |
| **ColumnGap** | defines the spacing between each column | 10px |
| **RowGap** | defines the spacing between each row | 10px |


## GridItem
A grid item wraps content and adds data which controls the positioning of the content.

Any grid item can be made to have horizontal and/or vertical scroll bars, allowing the content to scroll.

| Property | Description | Example|
|----|----|---|
| **Column** | defines the column number to render the content. (starting at 1), | 2 |
| **Row** | defines the row number to render the content. (starting at 1) | 2 |
| **ColumnSpan** | defines the the number of additional columns to span. (2 = 2 columns, 3 = 3 columns, etc.) | 3 |
| **RowSpan** | defines the number of additional rows to span (2 = 2 rows, 3 = 3 rows, etc.)| 2
| **HorizontalScrollbar** | allows you to scroll gridItem horizontally (none|auto|show) | auto |
| **VerticalScrollbar** | allows you to scroll gridItem vertically (none|auto|show) | auto |

## Example

Define your style sheet dynamiclly:

```html

@code {
    // define variables to hold the computed CSS class names
    private string mainGrid, innerGrid;
}

<!-- Define main grid container styles-->
<Styled @bind-Classname="@mainGrid">
    <!-- mainGrid is a container -->
    <GridContainer Rows="auto 1fr auto" RowGap="10px"
                   Columns="auto 1fr auto" ColumnGap="10px" />

    <!-- Define Row1 classes-->
    &-row1col1 {
        <GridItem Column="1" />
        border-style:solid;
        padding:10px;
        border-color: pink;
    }

    &-row1col2 {
        <GridItem Column="2" />
        border-style:solid;
        padding:10px;
        border-color: red;
    }

    &-row1col3 {
        <GridItem Column="3" />
        border-style:solid;
        padding:10px;
        border-color: blue;
    }

    <!-- define Row 2 classes-->
    &-row2 {
        <GridItem Row="2" Column="1" ColumnSpan="3" />
    }

    <!-- Define Row 3 classes -->
    &-row3col1 {
        <GridItem Row="3" Column="1" />
        border-style:solid;
        padding:10px;
        border-color: black;
    }

    &-row3col2 {
        <GridItem Row="3" Column="2" ColumnSpan="2" />
        border-style:solid;
        padding:10px;
        border-color: purple;
    }
</Styled>

<!--- define innerGrid class -->
<Styled @bind-Classname="@innerGrid">
    <!--- define that this is also a container and define container shape -->
    <GridContainer Rows="100%" RowGap="10px"
                   Columns="auto 1fr auto" ColumnGap="10px" />
    border-style:solid;
    padding:10px;
    border-color: chartruese;

    &-col1 {
        <GridItem Column="1" />
        background-color:lightsalmon;
        padding:10px;
    }

    &-col2 {
        <GridItem Column="2" VerticalScrollbar="Auto" />
        background-color: lightgreen;
    }

    &-col3 {
        <GridItem Column="3" />
        background-color: lightblue;
    }
</Styled>
```

Then use the classes in your markup

```html
<!-- Define actual html structure with CSS classes bound to the dynamicaly built CSS elements in the <Styled> tags below -->
<div class="@mainGrid">
    <div class="@mainGrid-row1col1">Row 1 Col 1</div>
    <div class="@mainGrid-row1col2">Row 1 Col 2</div>
    <div class="@mainGrid-row1col3">Row 1 Col 3</div>

    <div class="@mainGrid-row2 @innerGrid">
        <div class="@innerGrid-col1">
            @for (int i = 0; i < 1000; i++)
            {
                <p>This GridItem is cropped @i.</p>
            }
        </div>

        <div class="@innerGrid-col2">
            @for (int i = 0; i < 1000; i++)
            {
                <p>This GridItem should scroll @i.</p>
            }
        </div>
        <div class="@innerGrid-col3">
            @Body
        </div>
    </div>

    <div class="@mainGrid-row3col1">
        Row 3 Col 2
    </div>

    <div class="@mainGrid-row3col2">
        Row 3 Col 2/3<br />
    </div>
</div>
```


![screenshot.png](https://raw.githubusercontent.com/tomlm/BlazorCssGrid/master/screenshot.png)


## Important CSS trick for full screen layouts.
If you are using a Grid layout for your SPA you probably want your grid to fill the whole visible screen in a web browser.  
You can do this with the 100vh and 100vw width and height definitions, but you will find that many browsers end up adding 
a scrollbar when you do this. 

The solution is easy, you simply need to **disable the extra margins**.  In your CSS you can disable the padding and margin the browser is adding by simply adding this bit of CSS:
```css
* {
    box-sizing: border-box;
    padding: 0;
    margin: 0;
}
```

Now you can have your root grid container simply set the height and width to 100vh/100vw like this:
```html
<body height="100vh" width="100vh">
...
</body>
```


