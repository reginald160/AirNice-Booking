#pragma checksum "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0ac49ba31b14040699f15110b3ed45152741a15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.MyView_Views_Flight_AvailableFlight), @"mvc.1.0.view", @"/MyView/Views/Flight/AvailableFlight.cshtml")]
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
#nullable restore
#line 1 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\_ViewImports.cshtml"
using AirNiceWebMVC;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0ac49ba31b14040699f15110b3ed45152741a15", @"/MyView/Views/Flight/AvailableFlight.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf983abfcd5180e76c47dd2695faa631961b9b95", @"/MyView/Views/_ViewImports.cshtml")]
    public class MyView_Views_Flight_AvailableFlight : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AirNice.Models.DTO.FlightDTO>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger card-footer"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BookTicket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Booking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("deleteButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:50px; background-color:lightslategrey"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
  
    ViewData["Title"] = "AvailableFlight";
    Layout = "~/Views/Shared/_MainLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0ac49ba31b14040699f15110b3ed45152741a155169", async() => {
                WriteLiteral("\r\n    <section");
                BeginWriteAttribute("class", " class=\"", 231, "\"", 239, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n\r\n");
#nullable restore
#line 12 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                 if (Model.Any())
                {


                    var j = 1;
                    var imageNo = String.Empty;

                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                     foreach (var item in Model)
                    {

                        var count = Model.Count();
                        for (int i = 1; i < count; i++)
                        {
                            imageNo = $"{j++}.jpg";
                        }


#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"col-md-4  card mb30\"");
                BeginWriteAttribute("style", " style=\"", 791, "\"", 931, 6);
                WriteAttributeValue("", 799, "background-image:url(../../BLUETEC_HTML/images/gallery/", 799, 55, true);
#nullable restore
#line 28 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
WriteAttributeValue("", 854, imageNo, 854, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 862, ");", 862, 2, true);
                WriteAttributeValue(" ", 864, "background-size:auto;", 865, 22, true);
                WriteAttributeValue(" ", 886, "background-repeat:no-repeat;", 887, 29, true);
                WriteAttributeValue(" ", 915, "position:center", 916, 16, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <div class=\"de-image-hover card-title rounded\">\r\n\r\n\r\n                    </div>\r\n                    <div class=\"card-body\">\r\n\r\n\r\n                        <div> ");
#nullable restore
#line 36 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.FlightNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 37 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.AirLine));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 38 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.TotalVacantSeat));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 39 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.DepartureCountry));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 40 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.DepartureDateTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 41 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.DepartureCountry));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        <div> ");
#nullable restore
#line 42 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                         Write(Html.DisplayFor(modelItem => item.DepartureDateTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                      \r\n\r\n\r\n                    </div>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a0ac49ba31b14040699f15110b3ed45152741a1510095", async() => {
                    WriteLiteral("\r\n                        <i class=\"fa fa-trash-o\"></i> Book Flight\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 47 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                                                                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 51 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                       
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\PROGRESSIVE\source\repos\AirNice-Booking\AirNiceWeb\MyView\Views\Flight\AvailableFlight.cshtml"
                     
                  



                  }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n\r\n        </div>\r\n\r\n    </section>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AirNice.Models.DTO.FlightDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591