import { OperationResultModel } from "./operation-result";

export class GetManyResult<T> extends OperationResultModel {
    public entities: T[] = [];
    public totalAmount: number = 0;
}