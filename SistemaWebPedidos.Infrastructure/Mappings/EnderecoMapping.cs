using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
   
    
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id); //Define ID como Primary Key

            builder.Property(p => p.Rua)
                .IsRequired()  //Define o campo Rua como obrigatório
                .HasColumnType("varchar(200)"); //Define o campo Rua como tipo varchar(200)

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.HasOne(p => p.Usuario) //Define o relacionamento de 1:1
               .WithOne(f => f.Endereco); // com a tabela USUARIO

            builder.ToTable("ENDERECOS"); //Define o nome da Tabela
        }
    }



}
