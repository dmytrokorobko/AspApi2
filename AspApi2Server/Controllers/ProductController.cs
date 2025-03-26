using AspApi2Server.Domain;
using AspApi2Server.Domain.Entities;
using AspApi2Server.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApi2Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductContext _context;
    
    public ProductController(ILogger<ProductController> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("", Name = "getall")]
    public async Task<ActionResult<IEnumerable<Product>>> Get()
    {
        var products = await _context.Products.ToListAsync();
        if (products == null)
        {
            return NotFound();
        } else if (products.Count == 0)
        {
            return Ok();
        }
        else
        {
            return Ok(products);
        }
    }
    
    [HttpGet("{id}", Name = "getbyid")]
    public async Task<ActionResult<IEnumerable<Product>>> GetById([FromRoute]Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(product);
        }
    }

    [HttpPost(Name = "addproduct")]
    public async Task<IActionResult> Post([FromBody] ProductUpdateDto productDto)
    {
        Product product = new Product()
        {
            Id = Guid.NewGuid(),
            Name = productDto.Name,
            Price = productDto.Price,
            Category =  productDto.Category
        };
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}", Name = "updateproduct")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProductUpdateDto productDto)
    {
        if (id == Guid.Empty) 
            return BadRequest("Invalid id");
        
        var exisitng = await _context.Products.FindAsync(id);
        if (exisitng == null)
            return NotFound();
        
        exisitng.Name = productDto.Name;
        exisitng.Price = productDto.Price;
        exisitng.Category = productDto.Category;
        
        await _context.SaveChangesAsync();
        return Ok(exisitng);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (string.IsNullOrWhiteSpace(id.ToString())) 
            return BadRequest("Invalid id");
        
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound("Product was not assigned");
        
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return Ok("Product was deleted");
    }
}