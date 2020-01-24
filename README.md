# Blazor CSS Grid layout library
This blazor component makes it super easy to create application layouts for WebApps that look exactly how you want them to.

## Built 100% using CSS 
This library is built using <a href="https://www.w3schools.com/css/css_grid.asp">CSS Grids</a> which means there are 
no JS or CSS libraries to install.

It's usage is inspired by the kind of layouts you can achieve using XAML Grid Controls, and if you are familiar with
laying out an application's controls using grid semantics this will be very familiar to you.

# Install
Simply add a nuget package reference to **BlazorCssGrid**

```dotnet add BlazorCssGrid```

# Usage
There are 2 controls
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

```html

<GridContainer Rows="auto 1fr auto" Columns="auto 1fr auto" ColumnGap="10px" RowGap="10px">
    <!-- defines first row with 3 columns -->
    <GridItem Row="1" Column="1" style="border-color: pink; border-style:solid;padding:10px;">
        <p>Row 1 Col 1</p>
    </GridItem>

    <GridItem Row="1" Column="2" style="border-color: red; border-style:solid;padding:10px;">
        <p>Row 1 Col 2</p>
    </GridItem>

    <GridItem Row="1" Column="3" style="border-color: blue; border-style:solid;padding:10px;">
        <p>Row 1 Col 3</p>
    </GridItem>

    <!-- defines second row which spans the above 3 columns and defines a nested GridContainer made up of 3 columns -->
    <GridItem Row="2" Column="1" ColumnSpan="3" Style="border-color:chartreuse; border-style:dashed;">

        <GridContainer Columns="100px 1fr 100px" RowGap="10px" ColumnGap="10px" >
            <!-- defines column 1 as a gridItem with content but no scrollbars  -->
            <GridItem Column="1" style="background-color:lightsalmon;padding:10px;">
                @for (int i = 0; i < 1000; i++)
                {
                    <p>This GridItem is cropped @i.</p>
                }
            </GridItem>

            <!-- defines column 2 a gridItem with content has vertical scrollbars  -->
            <GridItem Column="2" VerticalScrollbar="Auto" Style="background-color: lightgreen;padding:10px;">
                @for (int i = 0; i < 1000; i++)
                {
                    <p>This GridItem should scroll @i.</p>
                }
            </GridItem>

            <!-- defines column 3 -->
            <GridItem Column="3" style="background-color: lightblue;padding:10px;">
                @Body
            </GridItem>

        </GridContainer>

    </GridItem>

    <!-- defines third row has 2 columns, one which spans the columns -->
    <GridItem Row="3" Column="1" style="border-color: black; border-style:solid;padding:10px;">
        Row 3 Col 2
    </GridItem>

    <GridItem Row="3" Column="2" ColumnSpan="2" style="border-color: purple; border-style: solid; padding: 10px;">
        Row 3 Col 2/3<br />
    </GridItem>
</GridContainer>
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
<GridContainer height="100vh" width="100vh">
...
</GridContainer>
```


