import { OperationResultModel } from "./operation-result";

export class GetOneResult<T> extends OperationResultModel {
    public entities: T;
}