﻿namespace Blog.Application.Pagination
{
    public interface IPaginationResponse<TData> where TData : class
    {
        IEnumerable<TData> Data { get; set; }
        int CurrentPage { get; set; }
        int QuantityPerPage { get; set; }
        long TotalRecords { get; set; }
        int TotalPages { get; set; }


    }
}