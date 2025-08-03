#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

namespace Dkd.Infra.Text;

public readonly record struct SvgMetadata(string Width, string Height, string ViewBox);
