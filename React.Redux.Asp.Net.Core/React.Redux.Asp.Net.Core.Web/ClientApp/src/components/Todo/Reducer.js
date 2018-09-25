import { REMOVE_TODO_ITEM, ADD_TODO_ITEM } from './Actions.Types';

const initialState = { todos: [] };
export default function reducer(state, action) {
    state = state || initialState;
    switch (action.type) {
        case ADD_TODO_ITEM:
            //[...state, action.payload]
            const added = {
                ...state,
                todos: state.todos.concat(action.payload)
            };
            return added;

        case REMOVE_TODO_ITEM:
            //state.filter(todo => { return todo.id !== action.payload });
            const removed = {
                ...state,
                todos: state.todos.filter(todo => { return todo.id !== action.payload })
            };
            return removed;

        default:
            return state;
    }
}