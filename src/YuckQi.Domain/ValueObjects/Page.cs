using System;
using System.Collections.Generic;
using YuckQi.Domain.ValueObjects.Abstract.Interfaces;

namespace YuckQi.Domain.ValueObjects;

public record Page(Int32 PageNumber, Int32 PageSize) : IPage;

public record Page<T>(IReadOnlyCollection<T> Items, Int32 TotalCount, Int32 PageNumber, Int32 PageSize) : Page(PageNumber, PageSize), IPage<T>;
