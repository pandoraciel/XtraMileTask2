#pragma checksum "D:\Project\Repos\XtraMileTask2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62654a984f9089c5707d6ae9feba928e2ecc4ce5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Project\Repos\XtraMileTask2\Views\_ViewImports.cshtml"
using XtraMileTask2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Repos\XtraMileTask2\Views\_ViewImports.cshtml"
using XtraMileTask2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62654a984f9089c5707d6ae9feba928e2ecc4ce5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2a7b6c3824706bfe00153083f5f97532f54bef5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Project\Repos\XtraMileTask2\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
    <div class=""card"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-md-4"">
                    <label>Country</label>
                    <select class=""custom-select"" id=""country"">
                    </select>
                </div>
                <div class=""col-md-4"">
                    <label>Region</label>
                    <select class=""custom-select"" id=""region"">
                    </select>
                </div>
                <div class=""col-md-4"">
                    <label>City</label>
                    <select class=""custom-select"" id=""city"">
                    </select>
                </div>
            </div>
        </div>
        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th>");
            WriteLiteral(@"Location</th>
                    <th>Time(s)</th>
                    <th>Wind(m/s)</th>
                    <th>Visibility(m)</th>
                    <th>Sky Condition</th>
                    <th>Temp(F)</th>
                    <th>Temp(C)</th>
                    <th>Dew Point(F)</th>
                    <th>Relative Humidity(%)</th>
                    <th>Pressure(hPa)</th>
                </tr>
            </thead>
            <tbody id=""data"">
                <tr>
                    <td colspan=""10"">Please select a city to show current weather data!</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/crc',
                type: 'GET',
                dataType: 'json',
                success: function (result) {
                    $('#country').empty();
                    var dt = '<option value="""">Choose a country!!</option>';
                    $.each(result, function (idx, val) {
                        dt += '<option value=""' + val.id + '"">' + val.name + '</option>';
                    });
                    $('#country').append(dt);
                }
            });

            $(document).on('change', '#country', function (e) {
                e.preventDefault();
                $.ajax({
                    url: '/api/crc/region/' + $('#country').val(),
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        $('#region').empty();
                        var dt = '<option value="""">Ch");
                WriteLiteral(@"oose a region!!</option>';
                        $.each(result, function (idx, val) {
                            dt += '<option value=""' + val.id + '"">' + val.name + '</option>';
                        });
                        $('#region').append(dt);
                    }
                });
            });

            $(document).on('change', '#region', function (e) {
                e.preventDefault();
                $.ajax({
                    url: '/api/crc/city/' + $('#region').val(),
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        $('#city').empty();
                        var dt = '<option value="""">Choose a city!!</option>';
                        $.each(result, function (idx, val) {
                            dt += '<option value=""' + val.name + '"">' + val.name + '</option>';
                        });
                        $('#city').append(dt);
                    }");
                WriteLiteral(@"
                });
            });

            $(document).on('change', '#city', function (e) {
                e.preventDefault();
                $.ajax({
                    url: 'https://api.openweathermap.org/data/2.5/weather?q=' + $('#city').val() +'&units=imperial&appid=7a96b60da9293dfa920765d2ab0be16f',
                    type: 'GET',
                    dataType: 'json',
                    success: function (result) {
                        console.log(result);
                        $('#data').empty();
                        var celcius = getCelcius(result.main.temp);
                        var dew = getDew(result.main.temp, result.main.humidity)
                        var dt = '';
                        dt += '<tr>';
                        dt += '<td>' + result.name + '</td>';
                        dt += '<td>' + result.dt + '</td>';
                        dt += '<td>' + result.wind.speed + '</td>';
                        dt += '<td>' + result.visibility + '</td>'");
                WriteLiteral(@";
                        dt += '<td>' + result.weather[0].description + '</td>';
                        dt += '<td>' + result.main.temp + '</td>';
                        dt += '<td>' + celcius + '</td>';
                        dt += '<td>' + dew + '</td>';
                        dt += '<td>' + result.main.humidity + '</td>';
                        dt += '<td>' + result.main.pressure + '</td>';
                        dt += '</tr>';
                            
                        $('#data').append(dt);
                        
                    },
                    error: function (jqXHR) {
                        //alert(""Data not found for city : "" + $('#city').val());
                        $('#data').empty();
                        var dt = '';
                        dt += '<tr><td colspan=10>No Data Found</td></tr>';
                        $('#data').append(dt);
                    }
                });
            });
        });

        function getCelcius(F) {");
                WriteLiteral(@"
            var res = $.ajax({
                url: '/api/crc/ftc/' + F,
                type: 'GET',
                dataType: 'json',
                async: false,
                success: function (result) {
                }
            });
            return getFormat(res.responseText);
            
        }

        function getDew(F, H) {
            var res = $.ajax({
                url: '/api/crc/dew/' + F +'/' + H,
                type: 'GET',
                dataType: 'json',
                async: false,
                success: function (result) {
                }
            });
            return getFormat(res.responseText);

        }

        function getFormat(f) {
            return f.replace(',', '.');
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
