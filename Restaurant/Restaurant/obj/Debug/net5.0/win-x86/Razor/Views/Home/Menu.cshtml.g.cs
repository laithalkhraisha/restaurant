#pragma checksum "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38cfd0a14aa9552aecb80452ba4ecc4c132ae68a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Menu), @"mvc.1.0.view", @"/Views/Home/Menu.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38cfd0a14aa9552aecb80452ba4ecc4c132ae68a", @"/Views/Home/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Restaurant.ViewModels.HomwModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "productDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
  
    ViewData["Title"] = "Menu";
    Layout = "_Layoutsub";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-area bg-img ptb-80"" style=""background-image:url(/assets/img/banner/breath.jpg);"">
            <div class=""container"">
                <div class=""breadcrumb-content text-center"">
                    <h3>menu</h3>
                    <ul>
                        <li>
                            <a href=""index.html"">Home</a>
                        </li>
                        <li class=""active"">menu page </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class=""product-menu-area pt-100 pb-70 gray-bg"">
            <div class=""container"">
                <div class=""section-title text-center mb-50"">
                    <h2>Our Food Menu</h2>
                    <p> Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim nostrud exercitation ullamco laboris nisi.</p>
                </div>
                <div class=""menu-tab-wrap mb-");
            WriteLiteral("50\">\r\n                    <div class=\"menu-tab-list nav text-center\">\r\n                        <a class=\"active\" href=\"#tab1\" data-bs-toggle=\"tab\">\r\n                            All item\r\n                        </a>\r\n");
#nullable restore
#line 31 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                         foreach (var item in Model.MasterCategoryMenu)
                       {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a");
            BeginWriteAttribute("href", " href=\"", 1478, "\"", 1514, 2);
            WriteAttributeValue("", 1485, "#", 1485, 1, true);
#nullable restore
#line 33 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
WriteAttributeValue("", 1486, item.MasterCategoryMenuName, 1486, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"tab\">\r\n                            ");
#nullable restore
#line 34 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                       Write(item.MasterCategoryMenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n");
#nullable restore
#line 36 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       \r\n                       \r\n                    </div>\r\n                </div>\r\n                <div class=\"tab-content jump\">\r\n                    <div id=\"tab1\" class=\"tab-pane active\">\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 44 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                             foreach (var item in Model.MasterItemMenu)
                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                               <div class=\"col-lg-6\">\r\n                                <div class=\"single-menu-product mb-30\">\r\n                                    <div class=\"menu-product-img\">\r\n                                        <img");
            BeginWriteAttribute("alt", " alt=\"", 2250, "\"", 2256, 0);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 2257, "\"", 2299, 2);
            WriteAttributeValue("", 2263, "/Images/", 2263, 8, true);
#nullable restore
#line 49 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
WriteAttributeValue("", 2271, item.MasterItemMenuImageUrl, 2271, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                    </div>
                                    <div class=""menu-product-content"">
                                        <div class=""menu-title-price"">
                                            <div class=""menu-title"">
                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38cfd0a14aa9552aecb80452ba4ecc4c132ae68a8115", async() => {
                WriteLiteral("  ");
#nullable restore
#line 54 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                                                            Write(Html.Raw(@item.MasterItemMenuTitle));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n                                            <div class=\"menu-price\">\r\n                                                <span>$");
#nullable restore
#line 57 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                                  Write(item.MasterItemMenuPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n                                        </div>\r\n                                        <p>");
#nullable restore
#line 60 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                      Write(item.MasterItemMenuDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 64 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 67 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                     foreach (var item in Model.MasterCategoryMenu)
                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                       <div");
            BeginWriteAttribute("id", " id=\"", 3396, "\"", 3429, 1);
#nullable restore
#line 69 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
WriteAttributeValue("", 3401, item.MasterCategoryMenuName, 3401, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"tab-pane\">\r\n                        <div class=\"row\">\r\n");
#nullable restore
#line 71 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                             foreach (var itemm in Model.MasterItemMenu.Where(x=>x.MasterCategoryMenuId==item.MasterCategoryMenuId))
                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                              <div class=\"col-lg-6\">\r\n                                <div class=\"single-menu-product mb-30\">\r\n                                    <div class=\"menu-product-img\">\r\n                                        <img");
            BeginWriteAttribute("alt", " alt=\"", 3896, "\"", 3902, 0);
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 3903, "\"", 3946, 2);
            WriteAttributeValue("", 3909, "/Images/", 3909, 8, true);
#nullable restore
#line 76 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
WriteAttributeValue("", 3917, itemm.MasterItemMenuImageUrl, 3917, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                    </div>
                                    <div class=""menu-product-content"">
                                        <div class=""menu-title-price"">
                                            <div class=""menu-title"">
                                                
                                                 ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38cfd0a14aa9552aecb80452ba4ecc4c132ae68a13174", async() => {
                WriteLiteral("  ");
#nullable restore
#line 82 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                                                             Write(Html.Raw(@itemm.MasterItemMenuTitle));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                \r\n                                            </div>\r\n                                            <div class=\"menu-price\">\r\n                                                <span>$");
#nullable restore
#line 86 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                                  Write(itemm.MasterItemMenuPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </div>\r\n                                        </div>\r\n                                        <p>");
#nullable restore
#line 89 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                                      Write(itemm.MasterItemMenuDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div> \r\n");
#nullable restore
#line 93 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            \r\n                           \r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 98 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       </div>\r\n                    </div>  \r\n        </div>\r\n       <div class=\"brand-logo-area ptb-100\">\r\n        <div class=\"container\">\r\n            <div class=\"brand-logo-active owl-carousel\">\r\n");
#nullable restore
#line 105 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
                 foreach (var item in Model.MasterPartner)
               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                   <div class=\"single-brand-logo\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 5477, "\"", 5521, 2);
            WriteAttributeValue("", 5484, "https://", 5484, 8, true);
#nullable restore
#line 108 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
WriteAttributeValue("", 5492, item.MasterPartnerWebsiteUrl, 5492, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "38cfd0a14aa9552aecb80452ba4ecc4c132ae68a17335", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5562, "~/Images/", 5562, 9, true);
#nullable restore
#line 109 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
AddHtmlAttributeValue("", 5571, item.MasterPartnerLogoImageUrl, 5571, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </a>\r\n                </div>\r\n");
#nullable restore
#line 112 "C:\asp.net core mvc\asp project\prject2\Restaurant\Restaurant\Views\Home\Menu.cshtml"
               }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \r\n               \r\n            </div>\r\n        </div>\r\n    </div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Restaurant.ViewModels.HomwModel> Html { get; private set; }
    }
}
#pragma warning restore 1591