namespace Code4Nothing.Blogs.Tags.Commands;

public class CreateTagCommand : IRequest<TagDto>
{
    public string Name { get; set; }
}

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagDto>
{
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<TagDto> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        return null;
    }
}
