import { Dictionary } from "../../";

export class SearchModel {
    public sortField: string;
    public sortDirection: string;
    public filters: Dictionary<string>;
}