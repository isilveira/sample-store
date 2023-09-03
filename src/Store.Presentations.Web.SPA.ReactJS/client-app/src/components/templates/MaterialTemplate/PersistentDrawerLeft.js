import React, { Fragment, useEffect } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';

import { push } from 'connected-react-router';
import md5 from 'md5';
import { ApplicationActionType } from '../../../state/actions';

import { useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Drawer from '@mui/material/Drawer';
import CssBaseline from '@mui/material/CssBaseline';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import ListItem from '@mui/material/ListItem';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import LabelIcon from '@mui/icons-material/Label';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import Button from '@mui/material/Button';

import { styled } from '@mui/material/styles';

import { SignManagerStart, SignInRedirect, SignInRedirectCallBack, SignOutRedirect, SignOutRedirectCallBack } from '../../../state/actions/signInManager/actions';

const drawerWidth = 240;

const StyledRoot = styled('div')(({ theme }) => ({
    ...theme.typography.body2,
    display: 'flex',
}));

const StyledAppBar = styled(AppBar, {
    shouldForwardProp: (prop) => prop !== 'open'
})(({ theme, open }) => ({
    transition: theme.transitions.create(['margin', 'width'], {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    ...(open && {
        width: `calc(100% - ${drawerWidth}px)`,
        marginLeft: `${drawerWidth}px`,
        transition: theme.transitions.create(['margin', 'width'], {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
    })
}));

const StyledDrawerHeader = styled('div')(({ theme }) => ({
    display: 'flex',
    alignItems: 'center',
    padding: theme.spacing(0, 1),
    ...theme.mixins.toolbar,
    justifyContent: 'flex-end',
}));

const StyledMain = styled('main', {
    shouldForwardProp: (prop) => prop !== 'open'
})(({ theme, open }) => ({
    flexGrow: 1,
    padding: theme.spacing(3),
    transition: theme.transitions.create('margin', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen,
    }),
    marginLeft: `-${drawerWidth}px`,
    ...(open && {
        transition: theme.transitions.create('margin', {
            easing: theme.transitions.easing.easeOut,
            duration: theme.transitions.duration.enteringScreen,
        }),
        marginLeft: 0,
    }),
}));

const LoginArea = (props) => {
    const { loggedUser, router } = props;

    useEffect(() => { console.log(`loggedUser: ${loggedUser}`); }, [loggedUser]);
    useEffect(() => { console.log(`router: ${router}`); console.log(router); }, [router]);
    const [anchorElUser, setAnchorElUser] = React.useState(false);
    const handleOpenUserMenu = (event) => {
        setAnchorElUser(event.currentTarget);
    };
    const handleCloseUserMenu = () => {
        setAnchorElUser(null);
    };
    const handleSignIn = () => {
        props.SignInRedirect();
    };
    const handleAccount = () => {
        window.location.href = "https://localhost:5001/Account/Manage";
    };
    const handleSignOut = () => {
        props.SignOutRedirect();
    };
    return (
        <Fragment>
            {loggedUser
                ? (
                    <Fragment>
                        <Box sx={{ flexGrow: 0, pr: 1 }}>
                            <Typography variant="h6" noWrap component="div">{loggedUser.profile.name}</Typography>
                        </Box>
                        <Box sx={{ flexGrow: 0 }}>
                            <Tooltip title="Open settings">
                                <IconButton onClick={handleOpenUserMenu} sx={{ p: 0 }}>
                                    {loggedUser?.profile?.email ? (<Avatar alt="Remy Sharp" src={`https://www.gravatar.com/avatar/${md5(loggedUser.profile.email)}?s=50`} />) : null}
                                </IconButton>
                            </Tooltip>
                            <Menu
                                sx={{ mt: '45px' }}
                                id="menu-appbar"
                                anchorEl={anchorElUser}
                                anchorOrigin={{
                                    vertical: 'top',
                                    horizontal: 'right',
                                }}
                                keepMounted
                                transformOrigin={{
                                    vertical: 'top',
                                    horizontal: 'right',
                                }}
                                open={Boolean(anchorElUser)}
                                onClose={handleCloseUserMenu}
                            >
                                <MenuItem onClick={handleAccount}>Account</MenuItem>
                                <MenuItem onClick={handleSignOut}>Sign Out</MenuItem>
                            </Menu>
                        </Box>
                    </Fragment>
                ) : (
                    <Box sx={{ flexGrow: 0 }}>
                        <Typography variant="h6" noWrap component="div">
                            <Button color="primary" variant="contained" onClick={handleSignIn}>Sign In</Button>
                        </Typography>
                    </Box>
                )}
        </Fragment>
    );
};

const PersistentDrawerLeft = (props) => {
    const theme = useTheme();
    const { application } = props;
    const handleDrawerOpen = () => {
        props.ApplicationMenuOpen();
    };
    const handleDrawerClose = () => {
        props.ApplicationMenuClose();
    };
    return (
        <StyledRoot>
            <CssBaseline />
            <StyledAppBar
                position="fixed"
                open={application.menu.isOpen}
            >
                <Toolbar>
                    <IconButton
                        color="inherit"
                        aria-label="open drawer"
                        onClick={handleDrawerOpen}
                        edge="start"
                        sx={{ mr: 2, ...(application.menu.isOpen && { display: 'none' }) }}>
                        <MenuIcon />
                    </IconButton>
                    <Box sx={{ flexGrow: 1 }}>
                        <Typography variant="h6" noWrap component="div">
                            {application.name}
                        </Typography>
                    </Box>
                    <LoginArea {...props} />
                </Toolbar>
            </StyledAppBar>
            <Drawer
                sx={{
                    width: drawerWidth,
                    flexShrink: 0,
                    '& .MuiDrawer-paper': {
                        width: drawerWidth,
                        boxSizing: 'border-box',
                    }
                }}
                variant="persistent"
                anchor="left"
                open={application.menu.isOpen}
            >
                <StyledDrawerHeader>
                    <IconButton onClick={handleDrawerClose} size="large">
                        {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
                    </IconButton>
                </StyledDrawerHeader>
                {
                    application.menu.groups.map((group, index) => (
                        <List key={group.key}>
                            <Divider />
                            {group.items.map((item, index) => (
                                <ListItem button key={item.key}
                                    selected={item.route === props.pathname}
                                    onClick={() => props.push(item.route)}
                                    disabled={item.isDisabled}>
                                    <ListItemIcon>{item.icon ? item.icon : <LabelIcon />}</ListItemIcon>
                                    <ListItemText primary={item.name} />
                                </ListItem>
                            ))}
                            <Divider />
                        </List>
                    ))
                }
            </Drawer>
            <StyledMain
                open={application.menu.isOpen}
            >
                <StyledDrawerHeader />

                {props.children}
            </StyledMain>
        </StyledRoot>
    );
}

const {
    ApplicationMenuOpen,
    ApplicationMenuClose,
} = ApplicationActionType.actions;

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    router: store.router,
    pathname: store.router.location.pathname,
    manager: store.SignInManagerState.manager,
    loggedUser: store.SignInManagerState.loggedUser,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        ApplicationMenuOpen,
        ApplicationMenuClose,
        SignManagerStart, SignInRedirect, SignInRedirectCallBack, SignOutRedirect, SignOutRedirectCallBack,
        push,
    }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(PersistentDrawerLeft);