import { Injectable, Inject } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Http, Response, Headers, RequestOptions, URLSearchParams } from "@angular/http";
import 'rxjs/add/operator/toPromise';
import { GetManyResult, PaginationModel, GetOneResult, GetCountResult, OperationResultModel  } from "../";

@Injectable()
export abstract class GenericHttpClientService<TEntity> {

    private _baseUrl: string;

    private headers: Headers;
    private params: URLSearchParams;
    private options: RequestOptions

    constructor(private http: Http, origemUrl: string, apiVersion: string, actionUrl: string) {

        this._baseUrl = origemUrl + 'api/' + apiVersion + '/' + actionUrl;

        this.params = new URLSearchParams();

        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        this.headers.append('Accept', 'application/json');

        this.options = new RequestOptions({ headers: this.headers, params: this.params });
    }

    async getAll(): Promise<GetManyResult<TEntity>> {

        let result: GetManyResult<TEntity> = new GetManyResult<TEntity>();

        try {
            const response = await this.http.get(this._baseUrl + '/GetAll', this.options).toPromise();

            if (response !== null && response !== undefined) {
                result = response.json() as GetManyResult<TEntity>;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async getById(id: number): Promise<GetOneResult<TEntity>> {

        let result: GetOneResult<TEntity> = new GetOneResult<TEntity>();

        this.options.params.append('id', id.toString());

        try {
            const response = await this.http.get(this._baseUrl + '/GetById', this.options).toPromise();

            if (response !== null && response !== undefined) {

                let serverResult = response.json() as GetOneResult<TEntity>;

                result = response.json() as GetOneResult<TEntity>;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async getMany(filter: PaginationModel): Promise<GetManyResult<TEntity>> {

        let result: GetManyResult<TEntity> = new GetManyResult<TEntity>();

        try {
            const response = await this.http.post(this._baseUrl + '/Search', JSON.stringify(filter), this.options).toPromise();

            if (response !== null && response !== undefined) {
                result = response.json() as GetManyResult<TEntity>;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async count(filter: PaginationModel): Promise<GetCountResult> {

        let result: GetCountResult = new GetCountResult();

        try {
            const response = await this.http.post(this._baseUrl + '/Count', filter, this.options).toPromise();

            if (response !== null && response !== undefined) {

                let serverResult = response.json() as GetCountResult;

                result = response.json() as GetCountResult;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async add(model: TEntity): Promise<GetOneResult<TEntity>> {

        let result: GetOneResult<TEntity> = new GetOneResult<TEntity>();

        try {
            const response = await this.http.post(this._baseUrl + '/Add', JSON.stringify(model), this.options).toPromise();

            if (response !== null && response !== undefined) {

                let serverResult = response.json() as GetOneResult<TEntity>;

                result = response.json() as GetOneResult<TEntity>;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async update(model: TEntity): Promise<OperationResultModel> {

        let result: OperationResultModel = new OperationResultModel();

        try {
            const response = await this.http.put(this._baseUrl + '/Update', JSON.stringify(model), this.options).toPromise();

            if (response !== null && response !== undefined) {

                let serverResult = response.json() as OperationResultModel;

                result = response.json() as OperationResultModel;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    async delete(id: number): Promise<OperationResultModel> {

        let result: OperationResultModel = new OperationResultModel();

        try {

            this.options.params.append('id', id.toString());

            const response = await this.http.delete(this._baseUrl + '/Delete', this.options).toPromise();

            if (response !== null && response !== undefined) {

                let serverResult = response.json() as OperationResultModel;

                result = response.json() as OperationResultModel;
            }
        } catch (e) {
            this.handleError(e);
        }

        return result;
    }

    // Function to throw errors
    private handleError(error: Response | any) {
        console.log(error);
        //return Observable.throw(error.json().error || 'Server error');
    }
}