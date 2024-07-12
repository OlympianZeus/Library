using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Library.Authors
{
    [Authorize(LibraryPermissions.Authors.Default)]
    public class AuthorAppService : LibraryAppService, IAuthorAppService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public AuthorAppService(
            IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }

        //SERVICES METHODS
        //1. GetAsync
        public async Task<AuthorDto> GetAsync(Guid id)
        {
            var author = await _authorRepository.GetAsync(id);
            return ObjectMapper.Map<Author, AuthorDto>(author);
        }
        //2. GetListAsync
        public async Task<PagedResultDto<AuthorDto>> GetListAsync(GetAuthorListDto input)
        {
            if(input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Author.Name);
            }

            var authors = await _authorRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );
            var totalCount = input.Filter == null
                ? await _authorRepository.CountAsync()
                : await _authorRepository.CountAsync(
                    author => author.Name.Contains(input.Filter));

            return new PagedResultDto<AuthorDto>(
                totalCount,
                ObjectMapper.Map<List<Author>, List < AuthorDto >> (authors)
            );
        }
        //3. CreateAsync
        [Authorize(LibraryPermissions.Authors.Create)]
        public async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {
            var author = await _authorManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio
                );
            await _authorRepository.InsertAsync(author);

            return ObjectMapper.Map<Author, AuthorDto>(author);
        }

        //4. UpdateAsync
        [Authorize(LibraryPermissions.Authors.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAuthorDto input)
        {
            var author = await _authorRepository.GetAsync(id);

            if(author.Name != input.Name)
            {
                await _authorManager.ChangeNameAsync(author, input.Name);
            }

            author.BirthDate = input.Birthdate;
            author.ShortBio = input.ShortBio;

            await _authorRepository.UpdateAsync(author);
        }
        //5. DeleteAsync

        [Authorize( LibraryPermissions.Authors.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }
    }
}
