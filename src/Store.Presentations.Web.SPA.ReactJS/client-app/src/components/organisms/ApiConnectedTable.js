import React, { useEffect, useState, useCallback, Fragment } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { debounce } from 'debounce';
import { CreateApiService, CreateApiFilter } from '../../state/actions/apiModelWrapper/actions';

import {
    lighten,
    alpha,
    Paper,
    Toolbar,
    Tooltip,
    Typography,
    IconButton,
    TableContainer,
    Table,
    TableHead,
    TableRow,
    TableCell,
    Checkbox,
    TableSortLabel,
    TableBody,
    TablePagination,
    InputBase,
} from '@mui/material';

import {
    Delete,
    Edit,
    FilterList,
    Add,
    Search
} from '@mui/icons-material';

import { styled } from '@mui/material/styles';

const StyledMainRoot = styled(Paper)(({theme})=>({
    width: '100%',
}));

const StyledToolbarRoot = styled(Toolbar, {
    shouldForwardProp: (prop) => prop !== 'length'
})(({theme, length})=>({
    paddingLeft: theme.spacing(2),
    paddingRight: theme.spacing(2),
    ...(length && length > 0  && {
        ...(theme.palette.mode === 'light' ? {
            color: theme.palette.secondary.main,
            backgroundColor: lighten(theme.palette.secondary.light, 0.85)
        } : {
            color: theme.palette.secondary.main,
            backgroundColor: theme.palette.secondary.dark
        })
    })
}));

const StyledToobarTitle = styled(Typography)(({theme})=>({
    flex: '1 1 100%',
}));

const StyledSearch = styled('div')(({theme})=>({
    position: 'relative',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: alpha(theme.palette.common.black, 0.05),
    '&:hover': {
        backgroundColor: alpha(theme.palette.common.black, 0.10),
    },
    marginRight: theme.spacing(2),
    marginLeft: 0,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
        marginLeft: theme.spacing(3),
        width: 'auto',
    },
}));

const StyledSearchIcon = styled('div')(({theme})=>({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({theme})=>({
    color: 'inherit',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        paddingLeft: `calc(1em + ${theme.spacing(4)})`,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('sm')]:{
            width: '12ch',
            '&:focus': {
                width: '20ch',
            },
        },
    },
}));

const StyledMainTable = styled(Table)(({theme}) => ({
    minWidth: 400,
}));

const StyledTableHeadRoot = styled(TableHead)(({theme})=>({
    fontWeight: 'bold'
}));

const StyledMainVisuallyHidden = styled('span')(({theme})=>({
    border: 0,
    clip: 'rect(0,0,0,0)',
    height: 1,
    margin: -1,
    overflow: 'hidden',
    padding: 0,
    position: 'absolute',
    top: 20,
    width: 1,
}));

const ApiConnectedTable = (props) => {
    const { config } = props;
    const { collections } = props;
    const [requestUrl, setRequestUrl] = useState(config.endPoint);
    const [response, setResponse] = useState(null);

    const api = props.CreateApiService(`${config.configId}-service`, config.endPoint);
    const filter = props.CreateApiFilter(`${config.configId}-filter`);

    const [query, setQuery] = useState('');
    const [selectedRows, setSelectedRows] = useState([]);
    const [pageRowCount, setPageRowCount] = useState(config.defaultPageSize);
    const [hasAllLinesChecked, setHasAllLinesChecked] = useState(false);
    const [hasLinesChecked, setHasLinesChecked] = useState(false);
    const emptyRows = response ? response.request.pagination.size - response.data.length : config.defaultPageSize;
    const loadData = () => {
        let url = api.GetByFilter(filter);
        setRequestUrl(url);
    };
    const debounceQuery = useCallback(debounce((value) => {
        let strict = response ? response.request.searchProperties.strict : false;
        let phrase = response ? response.request.searchProperties.phrase : false;
        filter.setSearch(value, strict, phrase);
        loadData();
    }, 3000, false), []);
    const handleRequestSort = (property) => (event) => {
        const isAscending = property === response.request.ordenation.orderBy && response.request.ordenation.order === 'ascending';
        const order = isAscending ? 'descending' : 'ascending';

        filter.setOrdenation(property, order);

        loadData();
    };
    const handleSelectAllClick = (event) => {
        if (event.target.checked) {
            const newSelecteds = response.data.map((value) => value[config.id]);
            setSelectedRows(newSelecteds);
            setHasAllLinesChecked(true);
            setHasLinesChecked(false);
            return;
        }
        setSelectedRows([]);
    };
    const handleClick = (event, id) => {
        const selectedIndex = selectedRows.indexOf(id);
        let newSelected = [];

        if (selectedIndex === -1) {
            newSelected = newSelected.concat(selectedRows, id);
        } else if (selectedIndex === 0) {
            newSelected = newSelected.concat(selectedRows.slice(1));
        } else if (selectedIndex === selectedRows.length - 1) {
            newSelected = newSelected.concat(selectedRows.slice(0, -1));
        } else if (selectedIndex > 0) {
            newSelected = newSelected.concat(
                selectedRows.slice(0, selectedIndex),
                selectedRows.slice(selectedIndex + 1),
            );
        }
        setSelectedRows(newSelected);
    };
    const handlePageChange = (event, newPage) => {
        filter.setPagination(response.request.pagination.size, newPage + 1);

        loadData();
    };
    const handleRowsPerPageChange = (event) => {
        filter.setPagination(event.target.value, 1);

        loadData();
    };
    const handleClickAdd = (event) => {
        config.actions['add'].handler();
    };
    const handleClickFilter = (event) => {
        console.log('click: handleClickFilter');
    };
    const handleClickEdit = (id) => (event) => {
        config.actions['edit'].handler(id);
    };
    const handleClickDelete = (event) => {
        config.actions['delete'].handler(selectedRows, () => {
            if (selectedRows.length === response.data.length) {
                handlePageChange(null, (response.request.pagination.number - 2));
            }

            setSelectedRows([]);
        });
    };
    const handleQuery = (event) => {
        setQuery(event.target.value);
    };
    const allowAction = (action) => {
        console.log({ action, actions: config.actions, access: config.actions[action], dispatch: props.dispatch, store: props.store });
        return config.actions !== undefined && config.actions !== null && config.actions[action] !== undefined && config.actions[action] !== null && (!config.actions[action].access || config.actions[action].access(props.dispatch, props.store));
    };
    useEffect(() => {
        loadData();
    });
    useEffect(() => {
        if (collections && collections[requestUrl] && collections[requestUrl].response) {
            setResponse(collections[requestUrl].response);
            setPageRowCount(collections[requestUrl].response.data.length);
        }
    }, [collections, requestUrl])
    useEffect(() => {
        setHasAllLinesChecked(selectedRows.length === pageRowCount);
        setHasLinesChecked(selectedRows.length < pageRowCount && selectedRows.length > 0);
    }, [selectedRows, pageRowCount]);
    useEffect(() => {
        debounceQuery(query);
    }, [query, debounceQuery]);
    return (
        <StyledMainRoot elevation={config.elevation || 0} >
            <StyledToolbarRoot length={selectedRows.length}>
                {selectedRows.length > 0 ? (
                    <StyledToobarTitle color="inherit" variant="subtitle1" component="div">
                        {selectedRows.length} {selectedRows.length > 1 ? 'itens selecionados' : 'item selecionado'}
                    </StyledToobarTitle>
                ) : (
                        <StyledToobarTitle variant="h6" id="tableTitle" component="div">
                            {config.title}
                        </StyledToobarTitle>
                    )}
                <StyledSearch>
                    <StyledSearchIcon>
                        <Search />
                    </StyledSearchIcon>
                    <StyledInputBase
                        placeholder="Search…"
                        inputProps={{ 'aria-label': 'search' }}
                        value={query}
                        onChange={handleQuery}
                    />
                </StyledSearch>

                {selectedRows.length > 0
                    ? (<Fragment>
                        { allowAction('edit') && selectedRows.length === 1 ? (<Tooltip title="Editar"><IconButton aria-label="edit" onClick={handleClickEdit(selectedRows[0])} size="large"><Edit /></IconButton></Tooltip>) : (null) }
                        { allowAction('delete') ? (<Tooltip title="Excluir"><IconButton aria-label="delete" onClick={handleClickDelete} size="large"><Delete /></IconButton></Tooltip>) : (null) }
                    </Fragment>)
                    : (<Fragment>
                        { allowAction('add') ? (<Tooltip title="Add item"><IconButton aria-label="add item" onClick={handleClickAdd} size="large"><Add /></IconButton></Tooltip>) : (null) }
                        { allowAction('filter') ? (<Tooltip title="Filter list"><IconButton aria-label="filter list" onClick={handleClickFilter} size="large"><FilterList /></IconButton></Tooltip>) : (null) }
                    </Fragment>)
                }
            </StyledToolbarRoot>
            <TableContainer>
                <StyledMainTable
                    aria-labelledby="tableTitle"
                    size={config.dense ? 'small' : 'medium'}
                    aria-label="api table">
                    <StyledTableHeadRoot>
                        <TableRow>
                            <TableCell padding="checkbox">
                                <Checkbox
                                    indeterminate={hasLinesChecked}
                                    checked={hasAllLinesChecked}
                                    onChange={handleSelectAllClick}
                                    inputProps={{ 'aria-label': 'select all desserts' }}
                                />
                            </TableCell>
                            {
                                config.columns.map((column) => (
                                    <TableCell
                                        key={column.id}
                                        align={column.align ? column.align : 'left'}
                                        padding={column.disablePadding ? 'none' : 'normal'}
                                        sortDirection={response && response.request.ordenation.orderBy === column.id ? response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : false}
                                    >
                                        <TableSortLabel
                                            style={{ fontWeight: 'bold' }}
                                            active={response && response.request.ordenation.orderBy === column.id}
                                            direction={response && response.request.ordenation.orderBy === column.id ? response.request.ordenation.order === 'ascending' ? 'asc' : 'desc' : 'asc'}
                                            onClick={handleRequestSort(column.id)}
                                        >
                                            {column.labelRender ? column.labelRender() : column.label}
                                            {response && response.request.ordenation.orderBy === column.id ? (
                                                <StyledMainVisuallyHidden>
                                                    {response.request.ordenation.order === 'ascending' ? 'sorted ascending' : 'sorted descending'}
                                                </StyledMainVisuallyHidden>
                                            ) : null}
                                        </TableSortLabel>
                                    </TableCell>
                                ))}
                        </TableRow>
                    </StyledTableHeadRoot>
                    <TableBody>
                        {response && response.statusCode === 200 ? response.data.map((value, index) => {
                            const isItemSelected = selectedRows.indexOf(value[config.id]) !== -1;
                            const labelId = `enhanced-table-checkbox-${index}`;
                            return (
                                <TableRow
                                    hover
                                    onClick={(event) => handleClick(event, value[config.id])}
                                    role="checkbox"
                                    aria-checked={isItemSelected}
                                    tabIndex={-1}
                                    key={value[config.id]}
                                    selected={isItemSelected}
                                >
                                    <TableCell padding="checkbox">
                                        <Checkbox
                                            checked={isItemSelected}
                                            inputProps={{ 'aria-labelledby': labelId }}
                                        />
                                    </TableCell>
                                    {config.columns.map(column => {
                                        const cellId = column.id + '-' + value[config.id];
                                        return (<TableCell key={cellId} align={column.align ? column.align : 'left'}>{column.valueRender ? column.valueRender(column.value ? column.value(value) : value[column.id]) : column.value ? column.value(value) : value[column.id]}</TableCell>)
                                    })}

                                </TableRow>
                            )
                        }) : null}
                        {config.showEmptyRows && emptyRows > 0 && (
                            <TableRow style={{ height: (config.dense ? 33 : 53) * emptyRows }}>
                                <TableCell colSpan={config.columns.length + 1} />
                            </TableRow>
                        )}
                    </TableBody>
                </StyledMainTable>
            </TableContainer>
            {response && response.statusCode === 200 ? (
                <TablePagination
                    rowsPerPageOptions={[5, 10, 25, 50, 100]}
                    component="div"
                    count={response.resultCount}
                    rowsPerPage={response.request.pagination.size}
                    page={response.request.pagination.number - 1}
                    onPageChange={handlePageChange}
                    onRowsPerPageChange={handleRowsPerPageChange}/>) : null }
        </StyledMainRoot>
    );
};

const mapStateToProps = store => ({
    store,
    application: store.ApplicationState.application,
    collections: store.ApiModelWrapperState.queries.collections
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        dispatch,
        CreateApiService,
        CreateApiFilter
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(ApiConnectedTable);

export default connectedComponent;
