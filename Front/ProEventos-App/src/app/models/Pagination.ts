export class Pagination {
  currentPage: number;
  ItemsPerPage: number;
  totalItems: number;
  totalPages:number;

}

export class PaginatedResult<T>{
  result: T;
  pagination: Pagination;
}
