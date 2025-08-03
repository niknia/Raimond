namespace Dkd.App.Admin.Application.Contracts.Dtos;

[Serializable]
public class DictDto : DictCreationDto
{
    public long Id { get; set; }
}

[Serializable]
public class DictDataDto : DictDataCreationDto
{
    public long Id { get; set; }
}
