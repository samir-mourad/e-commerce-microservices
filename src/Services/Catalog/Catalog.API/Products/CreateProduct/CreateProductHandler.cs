using Catalog.API.Models;
using Common.CQRS;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, IEnumerable<string> Category, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        return new CreateProductResult(Guid.NewGuid());
    }
}

