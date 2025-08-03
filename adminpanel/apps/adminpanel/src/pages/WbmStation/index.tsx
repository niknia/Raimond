import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput, NumberInput, Switch, Select } from '@mantine/core';
import { useWbmStation } from '@/data/WbmStation/wbmStation.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { WbmStationDto } from '@/data/WbmStation/wbmStation.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useWbmStation();
    const { data: wbmStationData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingStation, setEditingStation] = useState<WbmStationDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = wbmStationData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<WbmStationDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'nameFa',
            header: 'نام فارسی',
            size: 150,
        },
        {
            accessorKey: 'nameEn',
            header: 'نام انگلیسی',
            size: 150,
        },
        {
            accessorKey: 'trainCode',
            header: 'کد قطار',
            size: 100,
        },
        {
            accessorKey: 'showTrainCode',
            header: 'نمایش کد قطار',
            size: 120,
            cell: ({ getValue }) => (
                <Switch 
                    checked={getValue() as boolean} 
                    disabled 
                    size="sm"
                />
            ),
        },
        {
            accessorKey: 'isAirport',
            header: 'فرودگاه',
            size: 100,
            cell: ({ getValue }) => (
                <Switch 
                    checked={getValue() as boolean} 
                    disabled 
                    size="sm"
                />
            ),
        },
        {
            accessorKey: 'orderstation',
            header: 'ترتیب',
            size: 80,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: WbmStationDto) => {
        setEditingStation(row);
        open();
    };

    const handleDelete = async (row: WbmStationDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'ایستگاه با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف ایستگاه',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingStation(null);
        open();
    };

    const handleSave = async (values: Partial<WbmStationDto>) => {
        try {
            if (editingStation) {
                await updateMutation.mutateAsync({ id: editingStation.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'ایستگاه با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'ایستگاه جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت ایستگاه‌ها</Title>
                    <Text c="dimmed">مدیریت ایستگاه‌های قطار و فرودگاه</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingStation ? 'ویرایش ایستگاه' : 'افزودن ایستگاه جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام فارسی"
                            placeholder="نام فارسی ایستگاه"
                            defaultValue={editingStation?.nameFa || ''}
                            name="nameFa"
                        />
                        <TextInput
                            label="نام انگلیسی"
                            placeholder="نام انگلیسی ایستگاه"
                            defaultValue={editingStation?.nameEn || ''}
                            name="nameEn"
                        />
                        <NumberInput
                            label="کد قطار"
                            placeholder="کد قطار"
                            defaultValue={editingStation?.trainCode ?? undefined}
                            name="trainCode"
                        />
                        <Switch
                            label="نمایش کد قطار"
                            defaultChecked={editingStation?.showTrainCode || false}
                            name="showTrainCode"
                        />
                        <Switch
                            label="فرودگاه"
                            defaultChecked={editingStation?.isAirport || false}
                            name="isAirport"
                        />
                        <NumberInput
                            label="ترتیب"
                            placeholder="ترتیب نمایش"
                            defaultValue={editingStation?.orderstation ?? undefined}
                            name="orderstation"
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        nameFa: (formData.get('nameFa') as string) || '',
                                        nameEn: (formData.get('nameEn') as string) || '',
                                        trainCode: formData.get('trainCode') ? Number(formData.get('trainCode')) : undefined,
                                        showTrainCode: formData.get('showTrainCode') === 'on',
                                        isAirport: formData.get('isAirport') === 'on',
                                        orderstation: formData.get('orderstation') ? Number(formData.get('orderstation')) : undefined,
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingStation ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
}