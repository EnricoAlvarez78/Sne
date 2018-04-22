import { SearchModel } from "./search.model";

export class PaginationModel extends SearchModel {
    public pageIndex: number;
    public pageSize: number;
    public total: number;
}