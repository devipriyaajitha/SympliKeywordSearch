---
languages:
- csharp
- aspx-csharp
page_type: sample
description: "This is a sample application that you can use to search for a keyword and see positions of a specific URL list in googlesearch"
products:
---

# Sympli Keyword SEarch MVC app

UI has following controls
1. Keyword Textbox : Keyword to be searched
2. URL text box : Specific URL listing for the searched keyword
3. Search button, which calls google api for the specific keyword
4. Result label which list the positions the URL comes up as part of api response
	- If it lists for eg. 2,3,11, 22 - The URL is shown for the specified keywords in 2nd, 3rd, 11th and 22nd positions
	- If its 0, then it doesnt list the given URL for the specified keyword.
