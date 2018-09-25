import { REMOVE_TODO_ITEM, ADD_TODO_ITEM } from './Actions.Types';

export const removeTodo = id => {
    return {
        type: REMOVE_TODO_ITEM,
        payload: id
    };
};

export const addTodo = todo => {
    return {
        type: ADD_TODO_ITEM,
        payload: todo
    };
};