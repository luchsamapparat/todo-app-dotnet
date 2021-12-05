using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;

namespace SsrTodo.Pages;

public class HtmlGenerator : DefaultHtmlGenerator
{
    private Dictionary<string, string> _cssClassMapping = new Dictionary<string, string>() {
        // CSS class name for input validation
        { "input-validation-error", "is-invalid" },
        // CSS class name for valid input validation
        { "input-validation-valid", "" },
        // CSS class name for field validation error
        { "field-validation-error", "" },
        // CSS class name for valid field validation
        { "field-validation-valid", "" },
        // CSS class name for validation summary errors
        { "validation-summary-errors", "" },
        // CSS class name for valid validation summary
        { "validation-summary-valid", "" },
    };

    public HtmlGenerator(
        IAntiforgery antiforgery,
        IOptions<MvcViewOptions> optionsAccessor,
        IModelMetadataProvider metadataProvider,
        IUrlHelperFactory urlHelperFactory,
        HtmlEncoder htmlEncoder,
        ValidationHtmlAttributeProvider validationAttributeProvider
    ) : base(
        antiforgery,
        optionsAccessor,
        metadataProvider,
        urlHelperFactory,
        htmlEncoder,
        validationAttributeProvider
    )
    { }

    public override TagBuilder GenerateForm(
        ViewContext viewContext,
        string actionName,
        string controllerName,
        object routeValues,
        string method,
        object htmlAttributes)
    {
        var tagBuilder = base.GenerateForm(
            viewContext,
            actionName,
            controllerName,
            routeValues,
            method,
            htmlAttributes
        );

        if (!viewContext.ViewData.ModelState.IsValid)
        {
            tagBuilder.AddCssClass("FOO");
        }

        return tagBuilder;
    }

    public override TagBuilder GenerateSelect(
        ViewContext viewContext,
        ModelExplorer modelExplorer,
        string optionLabel,
        string expression,
        IEnumerable<SelectListItem> selectList,
        ICollection<string> currentValues,
        bool allowMultiple,
        object htmlAttributes
    )
    {
        return ReplaceValidationCssClasses(
            base.GenerateSelect(
                viewContext,
                modelExplorer,
                optionLabel,
                expression,
                selectList,
                currentValues,
                allowMultiple,
                htmlAttributes
            )
        );
    }

    public override TagBuilder GenerateTextArea(
        ViewContext viewContext,
        ModelExplorer modelExplorer,
        string expression,
        int rows,
        int columns,
        object htmlAttributes
    )
    {
        return ReplaceValidationCssClasses(
            base.GenerateTextArea(
                viewContext,
                modelExplorer,
                expression,
                rows,
                columns,
                htmlAttributes
            )
        );
    }

    public override TagBuilder GenerateValidationMessage(
        ViewContext viewContext,
        ModelExplorer modelExplorer,
        string expression,
        string message,
        string tag,
        object htmlAttributes
    )
    {
        return ReplaceValidationCssClasses(
            base.GenerateValidationMessage(
                viewContext,
                modelExplorer,
                expression,
                message,
                tag,
                htmlAttributes
            )
        );
    }

    public override TagBuilder GenerateValidationSummary(
        ViewContext viewContext,
        bool excludePropertyErrors,
        string message,
        string headerTag,
        object htmlAttributes
    )
    {
        return ReplaceValidationCssClasses(
            base.GenerateValidationSummary(
                viewContext,
                excludePropertyErrors,
                message,
                headerTag,
                htmlAttributes
            )
        );
    }

    protected override TagBuilder GenerateInput(
        ViewContext viewContext,
        InputType inputType,
        ModelExplorer modelExplorer,
        string expression,
        object value,
        bool useViewData,
        bool isChecked,
        bool setId,
        bool isExplicitValue,
        string format,
        IDictionary<string, object> htmlAttributes
    )
    {
        return ReplaceValidationCssClasses(
            base.GenerateInput(
                viewContext,
                inputType,
                modelExplorer,
                expression,
                value,
                useViewData,
                isChecked,
                setId,
                isExplicitValue,
                format,
                htmlAttributes
            )
        );
    }

    private TagBuilder ReplaceValidationCssClasses(TagBuilder tagBuilder)
    {
        var cssClasses = tagBuilder.Attributes.GetValueOrDefault("class");

        if (cssClasses == null)
        {
            return tagBuilder;
        }

        tagBuilder.Attributes["class"] = string.Join(",",
            cssClasses
                .Split(" ")
                .Select(cssClass => _cssClassMapping.GetValueOrDefault(cssClass, cssClass))
                .Where(cssClass => !string.IsNullOrEmpty(cssClasses))
        );

        return tagBuilder;
    }
}