import React, { useEffect, useState, useCallback, Fragment} from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import CircularProgress from '@mui/material/CircularProgress';
import { debounce } from 'debounce';
import { CreateApiService, CreateApiFilter } from '../../state/actions/apiModelWrapper/actions';

const ApiConnectedAutocomplete = props => {
  const api = props.CreateApiService(`${props.connectedId}-service`, props.endPoint);
  const filter = props.CreateApiFilter(`${props.connectedId}-filter`);
  const { entities, collections, defaultText, optionValue, optionText, disabled } = props;
  const [log, setLog] = useState('');
  const [requestUrl, setRequestUrl] = useState(props.endPoint);
  const [response, setResponse] = useState(null);
  const [requestValueUrl, setRequestValueUrl] = useState('');
  const [responseValue, setResponseValue] = useState(null);
  const [query, setQuery] = useState('');
  const [open, setOpen] = useState(false);
  const [loading, setLoading] = useState(false);
  const [options, setOptions] = useState([])
  const [value, setValue] = useState({text:'', value:''});
  
  const loadData = useCallback(() => {
    setLoading(true);
    let url = api.GetByFilter(filter);
    setRequestUrl(url);
  }, [api, filter, setRequestUrl]);

  const debounceQuery = useCallback(debounce((value) => {
      let strict = response ? response.request.searchProperties.strict : false;
      let phrase = response ? response.request.searchProperties.phrase : false;
      filter.setSearch(value, strict, phrase);
      loadData();
  }, 1500, false), []);

  const handleInputChange = (event, newInputValue) => {
    setQuery(newInputValue);
  };
  
  const mapOptions = useCallback((data) => {
    return { text: data[optionText], value: data[optionValue] }
  }, [optionValue, optionText]);

  useEffect(() => { console.log(`>> ${props.connectedId} => ${log}`)},[log, props.connectedId]);
  useEffect(() => { setLog('## ApiConnectedAutocomplete is rendered.'); }, []);

  useEffect(() => {
    setLog('log001 - useEffect');
    loadData();
  },[loadData]);

  useEffect(() => {
    if(response && response.data){
      setLog('-- ApiConnectedAutocomplete - SET OPTIONS');
      setOptions([{text: defaultText ?? 'Select...', value:''}, ...response.data.map(mapOptions)]);
    }
    setLoading(false);
  }, [response, mapOptions, defaultText]);

  useEffect(() => {
    setLog('log001 - useEffect - [filter]');
    filter.clear();
    filter.addResponseProperties([optionValue, optionText]);
  }, [filter, optionValue, optionText]);

  useEffect(() => {
    if(props.endPoint && props.value){
      setLog('log001 - useEffect - [api, props.value]');
      let idUrl = api.GetById(props.value);
      setRequestValueUrl(idUrl);
    } else if (!props.value) {
      setLog('log002 - useEffect - [api, props.value]');
      setQuery('');
      setValue({text:'', value:''});
      setRequestValueUrl('');
      setResponseValue({});
    }
    setLog('log003 - useEffect - [api, props.value]');
  }, [api, props.endPoint, props.value]);

  useEffect(() => {
    setLog('log001 - useEffect - [entities, requestValueUrl]');
      if (entities && entities[requestValueUrl] && entities[requestValueUrl].response) {
          setResponseValue(entities[requestValueUrl].response);
      }
  }, [entities, requestValueUrl])

  useEffect(() => {
    setLog('log001 - useEffect - [collections, requestUrl]');
      if (collections && collections[requestUrl] && collections[requestUrl].response) {
          setResponse(collections[requestUrl].response);
      }
  }, [collections, requestUrl]);

  useEffect(() => {
    setLog('log001 - useEffect - [query, debounceQuery]');
    debounceQuery(query);
  }, [query, debounceQuery]);

  useEffect(() => {
    setLog('log000 - useEffect - [responseValue]');
    if(responseValue && responseValue.data){
      setLog('log001 - useEffect - [responseValue]');
      setValue(mapOptions(responseValue.data));
    }
  },[responseValue, mapOptions]);

  return (
    <Autocomplete
      id={props.id}
      open={open}
      onOpen={() => {
        setOpen(true);
      }}
      onClose={() => {
        setOpen(false);
      }}
      disabled={disabled}
      isOptionEqualToValue={(option, value) => option.value === value.value }
      getOptionLabel={(option) => option?.text || ''}
      options={options}
      loading={loading}
      value={value}
      onChange={props.onChange}
      onInputChange={handleInputChange}
      renderInput={(params) => (
        <TextField
          {...params}
          label={props.label}
          error={props.error}
          helperText={props.helperText}
          InputProps={{
            ...params.InputProps,
            endAdornment: (
              <Fragment>
                {loading ? <CircularProgress color="inherit" size={20} /> : null}
                {params.InputProps.endAdornment}
              </Fragment>
            ),
          }}
        />
      )}
    />
  );
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    collections: store.ApiModelWrapperState.queries.collections,
    entities: store.ApiModelWrapperState.queries.entities,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        CreateApiService,
        CreateApiFilter
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(ApiConnectedAutocomplete);

export default connectedComponent;