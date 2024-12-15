using DomainModule.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ZolotukhinShop.Common;

public static class HtmlHelpers
{
    public static IHtmlContent IntNumericFilter(this IHtmlHelper htmlHelper, string label, string name,
        int? fromValue, int? toValue)
    {
        var divTag = new TagBuilder("div");
        divTag.AddCssClass("numeric_filter");
        divTag.AddCssClass("shadow-sm");

        var mainLabelTag = new TagBuilder("label");
        mainLabelTag.InnerHtml.AppendHtml(label);

        var fromInputTag = new TagBuilder("input");
        fromInputTag.Attributes.Add("type", "number");
        fromInputTag.Attributes.Add("name", $"{name}From");
        fromInputTag.Attributes.Add("step", "1");
        fromInputTag.Attributes.Add("value", fromValue.ToString());
        fromInputTag.Attributes.Add("placeholder", "От");

        var toInputTag = new TagBuilder("input");
        toInputTag.Attributes.Add("type", "number");
        toInputTag.Attributes.Add("name", $"{name}To");
        toInputTag.Attributes.Add("step", "1");
        toInputTag.Attributes.Add("value", toValue.ToString());
        toInputTag.Attributes.Add("placeholder", "До");

        divTag.InnerHtml
            .AppendHtml(fromInputTag)
            .AppendHtml(toInputTag);

        var htmlContent = new HtmlContentBuilder()
            .AppendHtml(mainLabelTag)
            .AppendHtml(divTag);

        return htmlContent;
    }

    public static IHtmlContent DoubleNumericFilter(this IHtmlHelper htmlHelper, string label, string name,
        double? fromValue, double? toValue)
    {
        var divTag = new TagBuilder("div");
        divTag.AddCssClass("numeric_filter");
        divTag.AddCssClass("shadow-sm");

        var mainLabelTag = new TagBuilder("label");
        mainLabelTag.InnerHtml.AppendHtml(label);

        var fromInputTag = new TagBuilder("input");
        fromInputTag.Attributes.Add("type", "number");
        fromInputTag.Attributes.Add("name", $"{name}From");
        fromInputTag.Attributes.Add("step", "0.01");
        fromInputTag.Attributes.Add("value", fromValue.ToString());
        fromInputTag.Attributes.Add("placeholder", "От");

        var toInputTag = new TagBuilder("input");
        toInputTag.Attributes.Add("type", "number");
        toInputTag.Attributes.Add("name", $"{name}To");
        toInputTag.Attributes.Add("step", "0.01");
        toInputTag.Attributes.Add("value", toValue.ToString());
        toInputTag.Attributes.Add("placeholder", "До");

        divTag.InnerHtml
            .AppendHtml(fromInputTag)
            .AppendHtml(toInputTag);

        var htmlContent = new HtmlContentBuilder()
            .AppendHtml(mainLabelTag)
            .AppendHtml(divTag);

        return htmlContent;
    }

    public static IHtmlContent AccordionCheckboxes(this IHtmlHelper htmlHelper, string label, string name,
        IEnumerable<string?> items, List<string?> checkedItems)
    {
        var topDivTag = new TagBuilder("div");
        topDivTag.AddCssClass("accordion");

        var divTag = new TagBuilder("div");
        divTag.AddCssClass("accordion-item");
        divTag.AddCssClass("shadow-sm");

        var h2Tag = new TagBuilder("h2");
        h2Tag.AddCssClass("accordion-header");
        h2Tag.Attributes.Add("id", $"{name}Heading");

        var buttonTag = new TagBuilder("button");
        buttonTag.AddCssClass("accordion-button");
        buttonTag.AddCssClass("collapsed");
        buttonTag.Attributes.Add("type", "button");
        buttonTag.Attributes.Add("data-bs-toggle", "collapse");
        buttonTag.Attributes.Add("data-bs-target", $"#{name}Collapse");
        buttonTag.Attributes.Add("aria-expanded", "false");
        buttonTag.Attributes.Add("aria-controls", $"{name}Collapse");
        buttonTag.InnerHtml.AppendHtml(label);

        h2Tag.InnerHtml.AppendHtml(buttonTag);

        var divCollapseTag = new TagBuilder("div");
        divCollapseTag.AddCssClass("accordion-collapse");
        divCollapseTag.AddCssClass("collapse");
        divCollapseTag.Attributes.Add("id", $"{name}Collapse");
        divCollapseTag.Attributes.Add("aria-labelledby", $"{name}Heading");

        var divBodyTag = new TagBuilder("div");
        divBodyTag.AddCssClass("accordion-body");
        divBodyTag.AddCssClass("d-flex");
        divBodyTag.AddCssClass("flex-column");
        divBodyTag.AddCssClass("gap-2");

        foreach (var item in items)
        {
            var divCheckboxTag = new TagBuilder("div");
            divCheckboxTag.AddCssClass("checkbox_input");
            divCheckboxTag.AddCssClass("d-flex");
            divCheckboxTag.AddCssClass("flex-row");
            divCheckboxTag.AddCssClass("gap-2");

            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("form-check-input");
            inputTag.Attributes.Add("type", "checkbox");
            inputTag.Attributes.Add("name", name);
            inputTag.Attributes.Add("value", item);
            if (checkedItems.Contains(item))
            {
                inputTag.Attributes.Add("checked", "checked");
            }

            var textTag = new TagBuilder("text");
            textTag.InnerHtml.AppendHtml($"{item}");

            divCheckboxTag.InnerHtml.AppendHtml(inputTag);
            divCheckboxTag.InnerHtml.AppendHtml(textTag);

            divBodyTag.InnerHtml.AppendHtml(divCheckboxTag);
        }

        divCollapseTag.InnerHtml.AppendHtml(divBodyTag);

        divTag.InnerHtml
            .AppendHtml(h2Tag)
            .AppendHtml(divCollapseTag);

        topDivTag.InnerHtml.AppendHtml(divTag);

        var htmlContent = new HtmlContentBuilder().AppendHtml(topDivTag);

        return htmlContent;
    }

    private static IHtmlContent DisplayAttributeIfNotNull(this IHtmlHelper htmlHelper, string label, object? value,
        string? valueTypeName = null)
    {
        if (value == null || value.ToString() == "")
        {
            return new HtmlString("");
        }

        var paragraphTag = new TagBuilder("p");

        var boldTag = new TagBuilder("b");
        boldTag.InnerHtml.AppendHtml(label + ": ");

        var textTag = new TagBuilder("text");
        if (valueTypeName == null) textTag.InnerHtml.AppendHtml($"{value}");
        else textTag.InnerHtml.AppendHtml(value + $" {valueTypeName}");

        paragraphTag.InnerHtml.AppendHtml(boldTag);
        paragraphTag.InnerHtml.AppendHtml(textTag);

        var htmlContent = new HtmlContentBuilder()
            .AppendHtml(paragraphTag);

        return htmlContent;
    }

    public static IHtmlContent DisplayAllAttributes(this IHtmlHelper htmlHelper, ProductModel product)
    {
        var htmlContent = new HtmlContentBuilder()
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Описание", product.Description))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Время жизни батареи", product.BatteryLifeTime, "ч"))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Разрешение камеры", product.CameraResolution, "MP"))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Версия ОС", product.OsVersion))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Тип интернет соединения", product.InternetConnectionType))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Диагональ экрана", product.ScreenDiagonal, "\""))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Объем памяти", product.MemorySize, "Гб"))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Тип матрицы экрана", product.DisplayMatrixType))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Вес", product.Weight, "кг"))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Название процессора", product.CpuName))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Объем оперативной памяти", product.RamSize, "Гб"))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Название видеокарты", product.GpuName))
            .AppendHtml(htmlHelper.DisplayAttributeIfNotNull("Цена", product.Price, "$"));
        return htmlContent;
    }
}